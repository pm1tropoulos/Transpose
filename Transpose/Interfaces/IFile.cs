﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transpose.Interfaces {
    public interface IFile {
        string Path { get; set; }
        Enums.fileType FileType { get; set; }
    }
}
