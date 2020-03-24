using System;
using Xunit;
using Xunit.Abstractions;

namespace TestSample.Test
{
    /// <summary>
    /// کلاسی جهت به اشتراک گذاشتن منابع 
    /// digeh lazem nabasheh har ja ke niyaz be person darim az person instance begirim
    /// در واقع منابع اینجا آماده می شود منابعی که زمان زیادی لازم است تا ساخته شود
    /// به عنوان مثال ایجاد بانک اطلاعاتی یا کارهایی از این نوع دسته
    /// </summary>
    public class PersonFixture 
    {
        public Person p = new Person(1, "mojtaba", "Evazzadeh", new DateTime(1984, 04, 27));
    }


    public class PersonTest : IClassFixture<PersonFixture>
    {
        private readonly ITestOutputHelper output;
        private readonly PersonFixture personFixture;

        public PersonTest(ITestOutputHelper output, PersonFixture personFixture)
        {
            this.output = output;
            this.personFixture = personFixture;
        }


        /// <summary>
        /// تست ساده
        /// </summary>
        [Fact]
        public void should_Mojtab_Evazzadeh_When_ToString_Mojtab_Evaazadeh()
        {
            //#AAA: Arrange - Act - Assert
            //Arrange
            Person p = new Person(1, "mojtaba", "Evazzadeh", new DateTime(1984, 04, 27));
            //Act
            var result = p.ToString();
            //Assert
            Assert.Equal("Mojtaba Evazzadeh".ToLower(), result.ToLower());
        }
        /// <summary>
        /// تست ساده
        /// </summary>
        [Fact]
        public void Should36WhenAge19840427()
        {
            //#AAA: Arrange - Act - Assert
            //Arrange
            Person p = new Person(1, "mojtaba", "Evazzadeh", new DateTime(1984, 04, 27));
            //Act
            var result = p.Age();
            //Assert
            Assert.Equal(36, result);
        }

        /// <summary>
        /// Throws
        /// خطا ها 
        /// </summary>
        [Fact]
        [Trait("Exception", "test")]
        public void ShouldThrowExeptionnWhenCallThrowEx01()
        {
            //#AAA: Arrange - Act - Assert
            //Arrange
            Person p = new Person(1, "mojtaba", "Evazzadeh", new DateTime(1984, 04, 27));
            //Act & Assert
            Assert.Throws<NotImplementedException>(() => p.ThrowEx01());
        }
        /// <summary>
        /// برای بسته بندی تست ها از عبارت زیر استفاده کن
        /// #Trait
        /// </summary>
        [Fact]
        [Trait("Exception", "test")]
        public void ShouldThrowExeptionnWhenCallThrowEx02()
        {
            //#AAA: Arrange - Act - Assert
            //Arrange
            Person p = new Person(1, "mojtaba", "Evazzadeh", new DateTime(1984, 04, 27));
            //Act & Assert
            Assert.Throws<NotImplementedException>(() => p.ThrowEx02());
        }
        /// <summary>
        /// غیر فعال کردن یک تست
        /// #Skip
        /// </summary>
        [Fact(Skip = "غیر فعال میکنیم این تست را با این پیغام")]
        public void Should36WhenAge19840427Version2()
        {
            //#AAA: Arrange - Act - Assert
            //Arrange
            Person p = new Person(1, "mojtaba", "Evazzadeh", new DateTime(1984, 04, 27));
            //Act
            var result = p.Age();
            //Assert
            Assert.Equal(36, result);
        }
        /// <summary>
        /// امکان نمایش خروجی برای یک تست 
        /// برای نمایش پیغام باید در 
        ///   Open additional output for this result
        ///   را بزنی در 
        ///   test explorer
        /// </summary>
        [Fact]
        public void ShowOutpot()
        {
            Assert.True(true);
            output.WriteLine("hello world");
        }
        /// <summary>
        /// برای به اشتراک گذاشتن منابع
        /// منظور کلاس هایی که نیاز هست
        /// need to arrange
        /// </summary>
        [Fact]
        public void ClassFixture()
        {
            //#AAA: Arrange - Act - Assert
            //Arrange
            //use fixture
            //Act
            var result = personFixture.p.Age();
            //Assert
            Assert.Equal(36, result);
        }














    }
}
