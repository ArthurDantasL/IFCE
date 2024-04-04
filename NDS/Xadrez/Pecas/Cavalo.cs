namespace Xadrez.pecas;

class Cavalo {

    // Estáticos:
    private static int quantidadeBranco = 0;
    private static int quantidadePreto = 0;

    // Atributos:
    private bool isBranco;
    private int positionX;
    private int positionY;

    // Construtor:
    public Cavalo(bool isBranco, bool isInicio) {
        this.isBranco = isBranco;
        
        if ((isBranco == true) && (isInicio == true)) {
            positionX = Cavalo.quantidadeBranco + 1 + Cavalo.quantidadePreto*4;
            positionY = 7;
            Cavalo.quantidadeBranco++;
            Tabuleiro t = new Tabuleiro();
            t.setMatrizDoTabuleiro(this.positionX, this.positionY, this.positionX, this.positionY, "\u265e");
        }
        
        if ((isBranco == false) && (isInicio == true)) {
            positionX = Cavalo.quantidadePreto + 1 + Cavalo.quantidadePreto*4;
            positionY = 0;
            Cavalo.quantidadePreto++;
            Tabuleiro t = new Tabuleiro();
            t.setMatrizDoTabuleiro(this.positionX, this.positionY, this.positionX, this.positionY, "\u2658");
        }
    }
}
