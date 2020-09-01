using System;
using Microsoft.AspNetCore.Mvc;
using velocityraptor.Model;

namespace velocityraptor.Services
{
    public interface IPersistenceService
    {
        void AddProject(Project project);
        Project GetProject(Guid id);
    }
}