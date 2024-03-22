using Dicom;
using FluentAssertions;

namespace ReadDicom.Domain.Tests;

public class DicomFileShould
{
    [Fact]
    public void Get_the_patient_name_and_modality_form_dicom_file()
    {
        var dicomFilePath = "image-00000.dcm";
        var dicomFile = DicomFile.Open(dicomFilePath);
        
        var patientName = dicomFile.Dataset.GetValue<string>(DicomTag.PatientName, 0);
        var modality = dicomFile.Dataset.GetValue<string>(DicomTag.Modality, 0);
        var toto = dicomFile.Dataset.GetValue<string>(DicomTag.PatientAge, 0);

        patientName.Should().Be("Anonymized");
        modality.Should().Be("OT");
    }
    
}