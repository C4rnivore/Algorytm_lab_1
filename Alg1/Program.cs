using System.Numerics;

var rsa = new RSACoder(7, 11);
rsa.encode_msg_from("D:\\Alg1\\Alg1\\RSA\\RSA Class\\Source.txt");
rsa.decode_msg_from("D:\\Alg1\\Alg1\\RSA\\RSA Class\\ResultEncoded.txt");



