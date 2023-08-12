using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Data.Models.Enums;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Resource;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace LearnWild.Services
{
    public class ResourceService : IResourceService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public ResourceService(ApplicationDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public async Task<bool> CreateResourseAsync(ResourceFormModel model)
        {
            try
            {
                var resource = new Resource()
                {
                    DisplayName = model.DisplayName,
                    TopicId = Guid.Parse(model.TopicId),
                };

                if (!string.IsNullOrEmpty(model.Url))
                {
                    resource.Url = model.Url;
                    resource.Type = ResourceType.Url;
                }
                else
                {
                    if (model.FormFile != null && model.FormFile.Length > 0)
                    {
                        string relativeFolderPath = Path.Combine(model.TopicId, Guid.NewGuid().ToString().ToUpperInvariant());
                        string absoluteFolderPath = Path.Combine(_environment.WebRootPath, "files", relativeFolderPath);

                        Directory.CreateDirectory(absoluteFolderPath);

                        using (var stream = new FileStream(Path.Combine(absoluteFolderPath, model.FormFile.FileName), FileMode.Create))
                        {
                            await model.FormFile.CopyToAsync(stream);
                        }

                        resource.FilePath = relativeFolderPath;
                        resource.Type = ResourceType.File;
                        resource.FileName = model.FormFile.FileName;
                        resource.MimeType = model.FormFile.ContentType;
                    }

                }

                _dbContext.Resources.Add(resource);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ExistsAsync(string topicId, string displayName)
        {
            return await _dbContext.Resources.AnyAsync(r => r.TopicId == Guid.Parse(topicId) && r.DisplayName == displayName);
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _dbContext.Resources.AnyAsync(r => r.Id == Guid.Parse(id));
        }

        public async Task<ResourceFileInfoModel?> GetResourseFileInfo(string id)
        {
            var resourse = await _dbContext.Resources.FindAsync(Guid.Parse(id));

            if (resourse == null || resourse.FilePath == null || resourse.FileName == null)
            {
                return null;
            }

            string filePath = Path.Combine(_environment.WebRootPath, "files", resourse.FilePath);

            var provider = new PhysicalFileProvider(filePath);
            var fileInfo = provider.GetFileInfo(resourse.FileName);
            if (!fileInfo.Exists)
            {
                return null;

            }

            var readStream = fileInfo.CreateReadStream();
            var mimeType = "application/octet-stream";

            return new ResourceFileInfoModel()
            {
                ReadStream = readStream,
                FileName = resourse.FileName ?? Guid.NewGuid().ToString(),
                MimeType = resourse?.MimeType ?? mimeType,
            };
        }
    }
}
