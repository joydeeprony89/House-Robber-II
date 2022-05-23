using System;

namespace House_Robber_II
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      int[] nums = new int[] { 3, 15, 1, 1, 4, 2, 19, 7, 1 };
    }
  }

  public class Solution
  {
    public int Rob(int[] nums)
    {
      int length = nums.Length;
      if (length == 1) return nums[0];
      if (length == 2) return Math.Max(nums[0], nums[1]);
      int rob0 = Rob0(nums);
      int rob1 = Rob1(nums);
      return Math.Max(rob0, rob1);
    }

    private int Rob0(int[] nums)
    {
      // 0 to n-2
      int length = nums.Length - 1;
      int[] temp = new int[length];
      Array.Copy(nums, 0, temp, 0, length);
      int lastIndex = length - 1;
      return Helper(temp, lastIndex, length, 0);
    }

    private int Rob1(int[] nums)
    {
      // 1 to n-1
      int length = nums.Length - 1;
      int[] temp = new int[length];
      Array.Copy(nums, 1, temp, 0, length);
      int lastIndex = length - 1;
      return Helper(temp, lastIndex, length, 0);
    }

    private int Helper(int[] temp, int lastIndex, int len, int firstIndex)
    {
      int max = int.MinValue;
      for (int i = lastIndex; i >= firstIndex; i--)
      {
        int nextIndex = i + 2;
        int maxRobbedAmount = temp[i];
        if (nextIndex < len)
        {
          max = Math.Max(max, temp[nextIndex]);
          maxRobbedAmount += max;
        }
        else
        {
          maxRobbedAmount += 0;
        }
        temp[i] = maxRobbedAmount;
      }
      return Math.Max(temp[0], temp[1]);
    }
  }
}
