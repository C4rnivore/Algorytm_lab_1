using System;

namespace Alg_lab_1
{
    public class BinaryInteger
    {
        public int[] Value { get; }
        private bool IsNegative { get; }
        public BinaryInteger(int number)
        {
            if (Math.Abs(number) > 255)
                throw new Exception("Число в десятичной форме записи должно находится в диапазоне от -255 до 255");

            IsNegative = number < 0;
            Value = ConverToBinary(Math.Abs(number), IsNegative);

        }
        public BinaryInteger(int[] value)
        {
            Value = value;
        }

        public static BinaryInteger operator +(BinaryInteger first, BinaryInteger second)
        {
            var transferByte = 0;
            var result = new BinaryInteger(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            for (var i = 7; i >= 0; i--)
            {
                var num = first.Value[i] + second.Value[i] + transferByte;
                if (num > 1)
                {
                    transferByte = 1;
                    num -= 2;
                }
                else
                    transferByte = 0;
                result.Value[i] = num;
            }
            return result;
        }
        public static BinaryInteger operator -(BinaryInteger first, BinaryInteger second)
        {
            var result = new BinaryInteger(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 });

            for (var i = 7; i >= 0; i--)
            {
                var num = first.Value[i] - second.Value[i];
                if (num == -1)
                {
                    result.Value[i] = 1;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (first.Value[j] == 1)
                        {
                            first.Value[j] = 0;
                            break;
                        }
                        else
                            first.Value[j] = 1;
                    }
                }
                else
                    result.Value[i] = num;
            }
            return result;
        }
        public static BinaryInteger operator *(BinaryInteger first, BinaryInteger second)
        {
            /*var result = new BinaryInteger(new int[]{0,0,0,0,0,0,0,0});
            var offset = 0;
            var previous= new int[]{0,0,0,0,0,0,0,0};
            var current= new int[]{0,0,0,0,0,0,0,0};
            var firstStep = true;


            for (var i = 7; i >= 0; i--)
            {
                if (firstStep)
                {
                    if(second.Value[i] == 0)
                    {
                        offset++;
                        firstStep = false;
                    }
                    else
                    {
                        offset++;
                        previous = first.Value;
                        firstStep = false;
                    }
                }
                else
                {
                    if(second.Value[i] == 0)
                    {
                        offset++;
                    }
                    else
                    {
                        var temp = first.Value;
                        for (int j = 0; j < temp.Length - 1; j++)
                        {
                            if (j <= temp.Length - 1 - offset)
                                temp[j] = temp[j + offset];
                            else
                                temp[j] = 0;
                        }
                        offset++;
                        current = temp;
                    }

                    previous = (new BinaryInteger(previous) + new BinaryInteger(current)).Value;
                    current = new int[]{0,0,0,0,0,0,0,0};
                }
            }
            return new BinaryInteger(previous);*/
            var f = Decode(first);
            var s = Decode(second);
            return new BinaryInteger(f * s);
        }
        public static BinaryInteger operator /(BinaryInteger first, BinaryInteger second)
        {
            var f = Decode(first);
            var s = Decode(second);
            return new BinaryInteger(f / s);
        }
        public static BinaryInteger operator %(BinaryInteger first, BinaryInteger second)
        {
            var f = Decode(first);
            var s = Decode(second);
            return new BinaryInteger(f % s);
        }
        public static bool operator <(BinaryInteger first, BinaryInteger second)
        {

            if (first.IsNegative && !second.IsNegative)
                return true;
            else if (!first.IsNegative && second.IsNegative)
                return false;
            else
            {
                bool flag = false;
                for (int i = 0; i < 8; i++)
                {
                    if (first.Value[i] < second.Value[i])
                    {
                        flag = true;
                        break;
                    }
                }
                return flag;
            }
        }
        public static bool operator >(BinaryInteger first, BinaryInteger second)
        {
            if (first.IsNegative && !second.IsNegative)
                return false;
            else if (!first.IsNegative && second.IsNegative)
                return true;
            else
            {
                bool flag = false;
                for (int i = 0; i < 8; i++)
                {
                    if (first.Value[i] > second.Value[i])
                    {
                        flag = true;
                        break;
                    }
                }
                return flag;
            }
        }
        public static bool operator ==(BinaryInteger first, BinaryInteger second)
        {
            for (int i = 0; i < 8; i++)
                if (first.Value[i] != second.Value[i]) return false;
            return true;
        }
        public static bool operator !=(BinaryInteger first, BinaryInteger second)
        {
            for (int i = 0; i < 8; i++)
                if (first.Value[i] != second.Value[i]) return true;
            return false;
        }




        private static int[] ConverToBinary(int num, bool negative)
        {
            var number = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            var index = 0;

            for (var i = 0; i < 8; i++)
            {
                var remains = num % 2;
                number[index] = remains;
                index++;
                num /= 2;
            }
            Array.Reverse(number);
            return negative ? Reverse(new BinaryInteger(number)).Value : number;
        }
        public static BinaryInteger Reverse(BinaryInteger num) //обратное по знаку число
        {
            var values = num.Value;

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i] == 0 ? 1 : 0;
            }

            var result = new BinaryInteger(values) + new BinaryInteger(1);
            return result;
        }
        private static int Decode(BinaryInteger num)
        {
            var arr = num.Value;
            var res = 0;

            for (var i = arr.Length - 1; i >= 0; i--)
            {
                res += (int)Math.Pow(2, 7 - i) * arr[i];
            }

            return res;
        }
    }
}