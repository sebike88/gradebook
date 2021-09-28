using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class EventTests
    {
      int count = 0;
      [Fact]
      public void WriteLogDelegateCanPointToMethod()
      {
        WriteLogDelegate log = new WriteLogDelegate(ReturnMessage);

        log += IncrementCount;

        var result = log("Hello!");

        Assert.Equal(2, count);
      }

      string IncrementCount(string message)
      {
        count += 1;
        return message.ToLower();
      }

      string ReturnMessage(string message)
      {
        count += 1;
        return message;
      }
    }
}
