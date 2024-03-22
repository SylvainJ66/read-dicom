using Dicom;

namespace ReadDicom.Domain;

public class Patient
{
    public string Name { get; }
    public string BirthDate { get; }
    public string Age { get; }
    public Patient(DicomFile dicomFile)
    {
        Name = dicomFile.Dataset.GetValueOrDefault(DicomTag.PatientName, 0, string.Empty);
        BirthDate = dicomFile.Dataset.GetValueOrDefault(DicomTag.PatientAge, 0, string.Empty);
        Age = dicomFile.Dataset.GetValueOrDefault(DicomTag.PatientAge, 0, string.Empty);
    }
}