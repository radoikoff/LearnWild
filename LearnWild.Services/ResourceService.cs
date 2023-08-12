using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Data.Models.Enums;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Resource;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
						string folderPath = Path.Combine(_environment.WebRootPath, "files", model.TopicId, Guid.NewGuid().ToString().ToUpperInvariant());
						string filePath = Path.Combine(folderPath, model.FormFile.FileName);

						Directory.CreateDirectory(folderPath);

						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await model.FormFile.CopyToAsync(stream);
						}

						resource.FilePath = filePath;
						resource.Type = ResourceType.File;
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
	}
}
