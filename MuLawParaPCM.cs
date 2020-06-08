using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio;
using NAudio.Wave.WaveFormats;
using NAudio.Wave;

namespace MuLawPCM
{
    class MuLawParaPCM
    {
        public Byte[] gravacaoB = new Byte[8];

        /*
         * Author: Danilo Oliveira Silva
         * contato: danilo.o.s@hotmail.com
         * 
        * Essa classe em C# serve para salvar um byte de informação em U-Law para um arquivo Wav utilizando a biblioteca NAudio.
        * Este código corrige um problema comum de decodificação de U-law dos audio, onde aparece a cada n segundos, um tom de batida
         * 
         * SalvarPCM(String PastaGravacoes, String nome, Byte[] gravacaoB, int rate, int bits)
         * PastaGravacoes = Pasta onde será gravado o arquivo
         * nome = nome do arquivo wav.
         * gravacaoB = vetor de bytes com o audio em u-law
         * rate = frequencia de amostragem -> ex: 8000 (Hz)
         * bits = quantidade de bits no pacote
         * 
         * Exemplo de chamada
         * MuLawParaPCM.SalvarPCM("C:\\gravacoes","teste.wav", bytes. 8000, 16)
        */


        public void SalvarPCM(String PastaGravacoes, String nome, Byte[] gravacaoB, int rate, int bits)
        {
            using (NAudio.Wave.WaveFileWriter writer = new NAudio.Wave.WaveFileWriter(PastaGravacoes + "\\" + nome, new NAudio.Wave.WaveFormat(rate, bits, 1)))
            {
                short[] amostrafinal = new short[gravacaoB.Length + 1000];
                int ind = 0;
                foreach (byte b in gravacaoB)
                {
                    short amostra = NAudio.Codecs.MuLawDecoder.MuLawToLinearSample(b);
                    amostrafinal[ind] = amostra;
                    ind++;
                }


                for (ind = 0; ind < amostrafinal.Length; ind++)
                {
                    if (amostrafinal[ind] < -16764)
                    {
                        try
                        {
                            amostrafinal[ind - 1] = 0;
                            amostrafinal[ind - 2] = 0;
                            amostrafinal[ind - 3] = 0;
                            amostrafinal[ind - 4] = 0;
                            amostrafinal[ind] = 0;
                            amostrafinal[ind + 1] = 0;
                            amostrafinal[ind + 2] = 0;
                            amostrafinal[ind + 3] = 0;
                            amostrafinal[ind + 4] = 0;
                        }
                        catch (Exception ex) { }
                    }
                }


                foreach (short amostra in amostrafinal)
                {
                    writer.WriteByte((byte)(amostra & 0xFF));
                    writer.WriteByte((byte)(amostra >> 8));
                }
                Console.Write("fim");

                
            }
        }
    }
}
