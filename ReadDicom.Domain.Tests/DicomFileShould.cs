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
        var test = dicomFile.Dataset.GetValueOrDefault<string>(DicomTag.ImageType, 0, string.Empty);
        
        var manufacturer = dicomFile.Dataset.GetValueOrDefault(DicomTag.Manufacturer, 0, string.Empty);
        var manufacturerModelName = dicomFile.Dataset.GetValueOrDefault(DicomTag.ManufacturerModelName, 0, string.Empty);
        var deviceSerialNumber = dicomFile.Dataset.GetValueOrDefault(DicomTag.DeviceSerialNumber, 0, string.Empty);
        var softwareVersions = dicomFile.Dataset.GetValueOrDefault(DicomTag.SoftwareVersions, 0, string.Empty);

        patientName.Should().Be("Anonymized");
        modality.Should().Be("OT");
    }
    
}