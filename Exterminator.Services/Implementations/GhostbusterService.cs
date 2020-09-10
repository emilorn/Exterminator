using System;
using System.Collections.Generic;
using Exterminator.Models.Dtos;
using Exterminator.Models.Exceptions;
using Exterminator.Models.InputModels;
using Exterminator.Repositories.Interfaces;
using Exterminator.Services.Interfaces;

namespace Exterminator.Services.Implementations
{
    public class GhostbusterService : IGhostbusterService
    {
        private readonly IGhostbusterRepository _ghostbusterRepository;

        public GhostbusterService(IGhostbusterRepository ghostbusterRepository)
        {
            _ghostbusterRepository = ghostbusterRepository;
        }

        public int CreateGhostbuster(GhostbusterInputModel ghostbuster) => _ghostbusterRepository.CreateGhostbuster(ghostbuster);

        public IEnumerable<GhostbusterDto> GetAllGhostbusters(string expertize = "") => _ghostbusterRepository.GetAllGhostbusters(expertize);

        public GhostbusterDto GetGhostbusterById(int id)
        {
            //throw new ResourceNotFoundException("Llolll");
            return _ghostbusterRepository.GetGhostbusterById(id);
        }
    }
}