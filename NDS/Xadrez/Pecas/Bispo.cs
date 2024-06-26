namespace Xadrez.pecas;

class Bispo {

    // Estáticos:
    private static int quantidadeBranco = 0;
    private static int quantidadePreto = 0;

    // Atributos:
    private bool isBranco;
    private int positionX;
    private int positionY;
    private string icon;

    // Construtor:
    public Bispo(bool isBranco, bool isInicio) {
        this.isBranco = isBranco;
        icon = (isBranco)? "\u265d" : "\u2657";
        
        if ((isBranco == true) && (isInicio == true)) {
            positionX = Bispo.quantidadeBranco + 2 + Bispo.quantidadePreto*2;
            positionY = 7;
            Bispo.quantidadeBranco++;            
            Tabuleiro.setMatrizDoTabuleiro(this.positionX, this.positionY, this.positionX, this.positionY, icon);
        }
        
        if ((isBranco == false) && (isInicio == true)) {
            positionX = Bispo.quantidadePreto + 2 + Bispo.quantidadePreto*2;
            positionY = 0;
            Bispo.quantidadePreto++;            
            Tabuleiro.setMatrizDoTabuleiro(this.positionX, this.positionY, this.positionX, this.positionY, icon);
        }
    }
    
    // Métodos:
    public void moverBispo(bool isBranco, int posX, int posY) {
        // Regra Geral:
        if (Rodada.regraGeral(posX, posY) == false) Console.WriteLine("[ERRO]: Posição Inválida.");

        // Regra de Alcance:        
        if (movimentoNoAlcance(posX, posY) == true) {
            Console.WriteLine("Movimento Permitido.");
            
            // Alterar Tabuleiro:
            Tabuleiro.setMatrizDoTabuleiro(this.positionX, this.positionY, posX, posY, icon);
            this.positionX = posX;
            this.positionY = posY;
        } 
        else {
            Console.WriteLine("Movimento Proíbido.");
        }   
    }

    public bool movimentoNoAlcance(int posX, int posY) {     
        
        int i = this.positionX; int j = this.positionY;
        int caminhoX = (this.positionX < posX)? 1 : -1;
        int caminhoY = (this.positionY < posY)? 1 : -1;
        int rangeX = (this.positionX < posX)? 7 : 0;
        int rangeY = (this.positionY < posY)? 7 : 0;      
        
        while (i != rangeX && j != rangeY) {
            i+=caminhoX; j+=caminhoY;
            if (Tabuleiro.getEntradaDaMatrizDoTabuleiro(i, j) != "[ ]") return (Rodada.fogoAmigo(this.isBranco, posX, posY) == true)? false : true;
            if (i == posX && j == posY) return true;            
        }
        return false;
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
