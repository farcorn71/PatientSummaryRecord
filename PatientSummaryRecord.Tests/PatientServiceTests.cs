using Moq;
using PatientSummaryRecord.Application.Exceptions;
using PatientSummaryRecord.Application.Interfaces;
using PatientSummaryRecord.Application.Services;
using PatientSummaryRecord.Domain;
using PatientSummaryRecord.Domain.Entities;
using Xunit;

namespace PatientSummaryRecord.Tests;

public class PatientServiceTests
{
    [Fact]
    public void GetPatientSummary_ReturnsPatient_WhenFound()
    {
        // Arrange
        var mockRepo = new Mock<IPatientRepository>();
        mockRepo.Setup(r => r.GetPatientById(1)).Returns(new Patient
        {
            Id = 1,
            Name = "Cornelius Smith",
            NHSNumber = "1234567890",
            DateOfBirth = new DateTime(1985, 4, 12),
            GPPractice = "Northumbria Healthcare"
        });

        var service = new PatientService(mockRepo.Object);

        // Act
        var result = service.GetPatientSummary(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Cornelius Smith", result.Name);
    }

    [Fact]
    public void GetPatientSummary_ThrowsException_WhenNotFound()
    {
        // Arrange
        var mockRepo = new Mock<IPatientRepository>();
        mockRepo.Setup(r => r.GetPatientById(It.IsAny<int>())).Returns((Patient)null);

        var service = new PatientService(mockRepo.Object);

        // Act & Assert
        Assert.Throws<PatientNotFoundException>(() => service.GetPatientSummary(99));
    }
}

