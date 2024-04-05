namespace Xadrez.pecas;

class Torre {

    // Estáticos:
    private static int quantidadeBranco = 0;
    private static int quantidadePreto = 0;

    // Atributos:
    private bool isBranco;
    private int positionX;
    private int positionY;

    // Métodos:
    public void MoverTorre(bool isBranco, int posX, int posY) {
        // Regra Geral:
        if ((posX < 0) || (posX > 7) || (posY < 0) || (posY > 7)) Console.WriteLine("[ERRO]: Posição Inválida.");

        // Regra de Alcance:
        //Console.WriteLine($"{this.positionX}, {this.positionY}");
        if ((MovimentoNoAlcance(posX, posY) == true) && (FogoAmigo(posX, posY) == false)) {
            Console.WriteLine($"{MovimentoNoAlcance(posX, posY)}, {FogoAmigo(posX, posY)}");            
            Console.WriteLine("Movimento Permitido.");
            Tabuleiro t = new Tabuleiro();
            if (isBranco == true)  t.setMatrizDoTabuleiro(this.positionX, this.positionY, posX, posY, "\u265c");
            if (isBranco == false) t.setMatrizDoTabuleiro(this.positionX, this.positionY, posX, posY, "\u2656");
            this.positionX = posX;
            this.positionY = posY;
        } 
        else {
            Console.WriteLine("Movimento Proíbido.");
        }       
        
    }

    public bool MovimentoNoAlcance(int posX, int posY) {
        if ((this.positionX == posX && this.positionY != posY) || (this.positionX != posX && this.positionY == posY)) return true;
        Console.WriteLine("Fora do Alcance");
        return false;
    }

    public bool FogoAmigo(int posX, int posY) {
        Console.WriteLine("Cond 0");
        Tabuleiro t = new Tabuleiro();
        if (this.positionX == posX && this.positionY < posY) {
            Console.WriteLine("Cond 1");                    
            for (int j = (this.positionY+1); j <= posY; j++) if (t.getEntradaDaMatrizDoTabuleiro(posX, j) != "[ ]") return true;
        }

        if (this.positionX > posX && this.positionY == posY) {
            Console.WriteLine("Cond 2");
            for (int i = (this.positionX-1); i >= posX; i--) if (t.getEntradaDaMatrizDoTabuleiro(i, posY) != "[ ]") return true;
        }

        if (this.positionX < posX && this.positionY == posY) {
            Console.WriteLine("Cond 3");
            for (int i = (this.positionX+1); i <= posX; i++) if (t.getEntradaDaMatrizDoTabuleiro(i, posY) != "[ ]") return true;
        }

        if (this.positionX == posX && this.positionY > posY) {
            Console.WriteLine("Cond 4");            
            for (int j = (this.positionY-1); j >= posY; j--) if (t.getEntradaDaMatrizDoTabuleiro(posX, j) != "[ ]") return true;
        }        
        Console.WriteLine("Não há colisão");
        return false;  
    }

    // Construtor:
    public Torre(bool isBranco, bool isInicio) {
        this.isBranco = isBranco;
        
        if ((isBranco == true) && (isInicio == true)) {
            positionX = Torre.quantidadeBranco*7;
            positionY = 7;
            Torre.quantidadeBranco++;
            Tabuleiro t = new Tabuleiro();
            t.setMatrizDoTabuleiro(this.positionX, this.positionY, this.positionX, this.positionY, "\u265c");
        }
        
        if ((isBranco == false) && (isInicio == true)) {
            positionX = Torre.quantidadePreto*7;
            positionY = 0;
            Torre.quantidadePreto++;
            Tabuleiro t = new Tabuleiro();
            t.setMatrizDoTabuleiro(this.positionX, this.positionY, this.positionX, this.positionY, "\u2656");
        }
    }
}
