# SalvarAudioMuLaw

Essa classe em C# serve para salvar um byte de informação em U-Law para um arquivo Wav utilizando a biblioteca NAudio.
Este código corrige um problema comum de decodificação de U-law dos audio, onde aparece a cada n segundos, um tom de batida

Essa classe utiliza a biblioteca NAudio
  
SalvarPCM(String PastaGravacoes, String nome, Byte[] gravacaoB, int rate, int bits)
  PastaGravacoes = Pasta onde será gravado o arquivo
  nome = nome do arquivo wav.
  gravacaoB = vetor de bytes com o audio em u-law
  rate = frequencia de amostragem -> ex: 8000 (Hz)
  bits = quantidade de bits no pacote
 
Exemplo de chamada
MuLawParaPCM.SalvarPCM("C:\\gravacoes","teste.wav", bytes. 8000, 16)
