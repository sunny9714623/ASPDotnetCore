﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class StudentEditViewModel : StudentCreateViewModel
    {
        public new int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
