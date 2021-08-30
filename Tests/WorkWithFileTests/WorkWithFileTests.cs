using Epam_Task_4;
using NUnit.Framework;
using FluentAssertions;
using Epam_Task_4.FileWork;

namespace Tests.WorkWithFileTests
{
    public class WorkWithFileTests
    {
        private const string PathA1 = @"..\..\..\..\Epam_Task_4\Resources\test1.A";
        private const string PathB1 = @"..\..\..\..\Epam_Task_4\Resources\test1.B";
        private const string PathDes1 = @"..\..\..\..\Epam_Task_4\Resources\test1.des";

        private const string PathA2 = @"..\..\..\..\Epam_Task_4\Resources\test2.A";
        private const string PathB2 = @"..\..\..\..\Epam_Task_4\Resources\test2.B";
        private const string PathDes2 = @"..\..\..\..\Epam_Task_4\Resources\test2.des";

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(PathA1)]
        [TestCase(PathA2)]
        public void Test_GetSystemMatrix(string filePath)
        {
            var fileWork = new FileExtention();
            var systemMatrix = fileWork.GetSystemMatrix(filePath);

            systemMatrix.Should().NotBeNull();
        }

        [TestCase(PathB1)]
        [TestCase(PathB2)]
        public void Test_GetFreeMembersCoeffs(string filePath)
        {
            var fileWork = new FileExtention();
            var systemMatrix = fileWork.GetFreeMembersCoeffs(filePath);

            systemMatrix.Should().NotBeNull();
        }

        [TestCase(PathA1, PathB1)]
        [TestCase(PathA2, PathB2)]
        public void Test_GetJoinedMatrix(string filePathA, string filePathB)
        {
            var fileWork = new FileExtention();
            var systemMatrix = fileWork.GetJoinedMatrix(filePathA, filePathB);

            systemMatrix.Should().NotBeNull();
        }

        [TestCase(PathA1, PathB1, PathDes1)]
        //[TestCase(PathA2, PathB2, PathDes2)]
        public void Test_GetAnswer(string filePathA, string filePathB, string filePathAnswer)
        {
            var fileWork = new FileExtention();
            var gauss = new GaussElimination();
            var systemMatrix = fileWork.GetJoinedMatrix(filePathA, filePathB);
            var expected = gauss.GetAnswer(systemMatrix);
            double delta = 0.00001;
            var result = fileWork.GetAnswer(filePathAnswer);

            for (var i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(result[i], expected[i], delta);
            }
        }
    }
}