﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.DtoLayer.Dtos.ApplicationUserDto
{
    public class ApplicationUserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
        public ApplicationUser Data { get; set; }
    }
}
