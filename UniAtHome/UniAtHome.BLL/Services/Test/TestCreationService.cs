using System;
using System.Collections.Generic;
using System.Text;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.DAL.Interfaces;
using TestEntity = UniAtHome.DAL.Entities.Tests.Test;

namespace UniAtHome.BLL.Services.Test
{
    public class TestCreationService : ITestCreationService
    {
        private readonly IRepository<TestEntity> tests;

    }
}
