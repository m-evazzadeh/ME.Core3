using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace TestSample.Test
{
    /// <summary>
    /// shared data with Attribute
    /// </summary>
    public class DataProvider1Attribute : DataAttribute
    {
        
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            List<object[]> data = new List<object[]>();
            data.Add(new object[] { 1, 2, 3 });
            data.Add(new object[] { 10, 20, 30 });
            data.Add(new object[] { 1, 20, 21 });
            return data;
        }
    }

    /// <summary>
    /// shared data with code
    /// </summary>
    public static class DataProvider
    {
        public static List<object[]> GetData()
        {
            List<object[]> data = new List<object[]>();
            data.Add(new object[] { 1, 2, 3 });
            data.Add(new object[] { 10, 20, 30 });
            data.Add(new object[] { 1, 20, 21 });
            return data;
        }
    }

    /// <summary>
    /// نحوه استفاده از دیتا برای اجرای تست
    /// </summary>
    public class MyMathTest
    {
        /// <summary>
        /// در زمانی که بخواهیم حالت های مختلف را تست کنیم
        /// البته نکته مهمی که وجود دارد این روش قابلیت اشتراک گذاری همین داده را ندارد و همچنین 
        /// برنامه نویس می تواند عوض کند این را
        /// </summary>
        /// <param name="number01"></param>
        /// <param name="number02"></param>
        /// <param name="result"></param>
        [Theory]
        //در واقع به تعداد پارامتر زیر باید در متد تست پارامتر وجود داشته باشد
        [InlineData(1,2,3)]
        [InlineData(10,20,30)]
        [InlineData(1,20,21)]
        public void AddTestWithInlineData(int number01,int number02,int result)
        {
            MyMath m = new MyMath();
            var retVal = m.Add(number01, number02);
            Assert.Equal(result, retVal);
        }

        /// <summary>
        /// در صورتی که نیاز باشد از دیتا تست در چندین جا بخواهیم استفاده بکنیم و قابلیت اشتراک گذاری دیتا وجود داشته باشد 
        /// باید از روش زیر استفاده کرد
        /// </summary>
        /// <param name="number01"></param>
        /// <param name="number02"></param>
        /// <param name="result"></param>
        [Theory]
        [MemberData(nameof(DataProvider.GetData),MemberType = typeof(DataProvider))]
        public void AddTestWithSharedData(int number01, int number02, int result)
        {
            MyMath m = new MyMath();
            var retVal = m.Add(number01, number02);
            Assert.Equal(result, retVal);
        }

        /// <summary>
        /// estefadeh az attribute 
        /// </summary>
        /// <param name="number01"></param>
        /// <param name="number02"></param>
        /// <param name="result"></param>
        [Theory]
        [DataProvider1]
        public void AddTestWithSharedData1(int number01, int number02, int result)
        {
            MyMath m = new MyMath();
            var retVal = m.Add(number01, number02);
            Assert.Equal(result, retVal);
        }

    }
}
