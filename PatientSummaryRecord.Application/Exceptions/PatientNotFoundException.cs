using System;
using System.Collections.Generic;
using System.Text;

namespace PatientSummaryRecord.Application.Exceptions
{
    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(int id)
            : base($"Patient with ID {id} was not found.") { }
    }

}
