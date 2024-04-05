namespace Xadrez.pecas;

class Rei {
    
    // Estáticos:
    private static int quantidadeBranco = 0;
    private static int quantidadePreto = 0;

    // Atributos:
    private bool isBranco;
    private int positionX;
    private int positionY;

    // Construtor:
    public Rei(bool isBranco, bool isInicio) {
        this.isBranco = isBranco;
        
        if ((isBranco == true) && (isInicio == true)) {
            positionX = 4;
            positionY = 7;
            Rei.quantidadeBranco++;
            //Tabuleiro t = new Tabuleiro();
            Tabuleiro.setMatrizDoTabuleiro(this.positionX, this.positionY, this.positionX, this.positionY, "\u265a");
        }
        
        if ((isBranco == false) && (isInicio == true)) {
            positionX = 4;
            positionY = 0;
            Rei.quantidadePreto++;
            //Tabuleiro t = new Tabuleiro();
            Tabuleiro.setMatrizDoTabuleiro(this.positionX, this.positionY, this.positionX, this.positionY, "\u2654");
        }
    }

    // GettersAndSetters:

    public bool IsBranco {
        get { return isBranco; }
        //set { isBranco = value; }
    }
    
    public int PositionX {
        get { return positionX; }
        //set { positionX = value; }
    }
    
    public int PositionY {
        get { return positionY; }
        //set { positionY = value; }
    }    
}
