﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.API.Model.Note
{
    public class GetNotesResponse
    {
        public IEnumerable<WC.DTO.Note> Notes { get; set; }
    }
}
