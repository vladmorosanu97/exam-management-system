﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamsSystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamsSystem.Data.Implementation
{
    public class ExamRepository: IExamRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ExamRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void GetDataTest()
        {
        }
    }
}
