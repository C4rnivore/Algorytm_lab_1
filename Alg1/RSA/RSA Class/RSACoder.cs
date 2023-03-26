
using System;
using System.Numerics;
using System.Reflection;
using System.Text;

public class RSACoder
{
    public long p { get; private set; }
    public long q { get; private set; }
    public long n { get; private set; }
    public long e;
    private long d;
    public long phi { get; private set; }

    public Tuple<long, long> open_key { get; private set; }
    private Tuple<long, long> closed_key;
    public RSACoder(long prime1, long prime2) // предварительные действия
    {
        if ((!is_prime(prime1) || !is_prime(prime2)) || prime1 == prime2) 
            throw new Exception("Prime1 and prime2 must be prime! And not the same");

        this.p = prime1;
        this.q = prime2;
        this.n = p*q;
        this.phi = (p - 1) * (q - 1);
        set_e(phi);
        set_d(e, phi);
        this.open_key = new Tuple<long, long>(e, n);
        this.closed_key = new Tuple<long, long>(d, n);
    }

    // Методы кодирования и декодирования
    public void encode_msg_from(string input_file_path)
    {
        var SAVING_PATH = "D:\\Alg1\\Alg1\\RSA\\RSA Class\\ResultEncoded.txt";
        var saving_list = new List<string>();
        var e = open_key.Item1;
        var n = open_key.Item2;
        var chars = new char[] {'A','B','C','D','E','F','G',
                                 'H','I','J','K','L','M','N','O',
                                 'P','Q','R','S','T','U','V','W',
                                 'X','Y','Z','1','2','3','4','5','6','7','8','9','0',
                                 ' ', ',', '.', '!', '?','\'',':',';'};

        var sr = new StreamReader(input_file_path);
        var sb = new StringBuilder();
        while(!sr.EndOfStream)
        {
            sb.Append(sr.ReadLine());
        }
        sr.Close();

        foreach(var c in sb.ToString().ToUpper()) {
            var index = Array.IndexOf(chars, c);

            var bi = new BigInteger(index);
            bi = BigInteger.Pow(bi, (int)e);

            BigInteger n_ = new BigInteger((int)n);

            bi = bi % n_;
            saving_list.Add(bi.ToString());
        }
        save_to_file(saving_list, "D:\\Alg1\\Alg1\\RSA\\RSA Class\\ResultEncoded.txt");
        Console.WriteLine("Your message have been encoded succesfully");

    }
    public void decode_msg_from(string input_file_path)
    {
        var SAVING_PATH = "D:\\Alg1\\Alg1\\RSA\\RSA Class\\ResultDecoded.txt";
        var saving_list = new List<string>();
        var result_list = new List<string>();
        var d = closed_key.Item1;
        var n = closed_key.Item2;
        var chars = new char[] {'A','B','C','D','E','F','G',
                                 'H','I','J','K','L','M','N','O',
                                 'P','Q','R','S','T','U','V','W',
                                 'X','Y','Z','1','2','3','4','5','6','7','8','9','0',
                                 ' ', ',', '.', '!', '?','\'',':',';'};

        var sr = new StreamReader(input_file_path);
        var sb = new StringBuilder();
        while( !sr.EndOfStream ) {
            saving_list.Add(sr.ReadLine());
        }
        sr.Close();

        foreach (var item in saving_list)
        {
            var E = long.Parse(item);
            var bi = new BigInteger(E);
            bi = BigInteger.Pow(bi, (int)d);

            BigInteger n_ = new BigInteger((int)n);

            bi = bi % n_;
            sb.Append(chars[int.Parse(bi.ToString())]);
        }

        var res = sb.ToString().Split(' ').ToList();
        save_to_file(res, SAVING_PATH);
        Console.WriteLine("Your message have been decoded succesfully");
    }

    // Методы генерирующие атрибуты ключей
    private void set_d(long e, long phi)
    {
        var d = 0;
        while((d*e)%phi != 1)
        {
            d++;
        }
        this.d = d;
    }
    private void set_e(long phi) //Решето Эрастофена, ищет все простые числа меньше n
    {
        var numbers = new List<long>();
        var breaker = (long)Math.Sqrt(phi);//все числа до корня квадратного из phi

        for (int i = 2; i < phi; i++)
            numbers.Add(i);

        for (int i = 2; i < breaker; i++)
            for (int j = 0; j < numbers.Count; j++)
                if (numbers[j] % i == 0)
                    numbers.RemoveAt(j);
        foreach (var item in numbers)
        {
            if(is_coprime(item,phi))
                this.e= item;
            else
            {
                throw new Exception("Cant find coprime e");
            }
        }
    }


    //Вспомогательные методы
    private void save_to_file(List<string> input, string output_file_path)
    {
        StreamWriter sw = new StreamWriter(output_file_path);
        sw.Write(String.Empty);
        foreach (var item in input)
            sw.WriteLine(item);
        sw.Close();
        
    }
    public bool is_prime(long num)
    {
        for (int i = 2; i <= num / 2; i++)
            if (num % i == 0)
                return false;
        return true;
    }
    public bool is_coprime(long a, long b)
    {
        return a == b
               ? a == 1
               : a > b
                    ? is_coprime(a - b, b)
                    : is_coprime(b - a, a);
    }

}