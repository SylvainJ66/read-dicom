using Dicom;

namespace ReadDicom.Domain.Tests;

public class DicomFactory
{
    private readonly DicomFile _dicomFile;
    public DicomFactory(string path)
    {
        _dicomFile = DicomFile.Open(path);
    }
    public Patient CreatePatient()
    {
        return new Patient(_dicomFile);
    }
}