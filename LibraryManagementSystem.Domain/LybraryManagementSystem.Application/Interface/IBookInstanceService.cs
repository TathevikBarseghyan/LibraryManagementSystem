﻿using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.BookInstance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IBookInstanceService
    {
        Task AddRangeAsync(List<BookInstanceModel> bookInstanceModels);
        Task<List<BookInstanceModel>> GetAllAsync();
        Task<BookInstanceModel> GetByIdAsync(int bookInstanceModelId);
        Task<List<BookInstanceModel>> GetByBookIdAsync(int bookId);
        Task DeleteAsync(int bookInstanceModelId);
        Task UpdateAsync(BookInstanceModel bookInstanceModel);
        Task SaveChangesAsync();
        
    }
}
