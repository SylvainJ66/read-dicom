using FluentAssertions;

namespace ReadDicom.Domain.Tests;

public class PatientShould
{
    [Fact]
    public void Patient_should_be_created_from_dicom_file()
    {
        var dicomFilePath = "image-00000.dcm";
        
        var patient = new Patient(dicomFilePath);
        
        patient.Should().BeEquivalentTo(new
        {
            Name = "Anonymized",
            BirthDate = string.Empty,
            Age = string.Empty
        });
    }
}