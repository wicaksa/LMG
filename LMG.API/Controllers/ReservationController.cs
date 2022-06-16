﻿using LMG.API.Controllers.LMG.API.Controllers;
using LMG.BLL.Models;
using LMG.DAT.Models.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : LMGControllerBase<ReservationModel, DC_Reservation>
    {
        public ReservationController(DAT.Interfaces.GenericRepository<DC_Reservation> repository) : base(repository)
        {
        }
    }
}
