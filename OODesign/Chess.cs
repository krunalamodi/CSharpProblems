enum playerType { black, white };

interface IPiece {
	playerType type;
	bool moveTo (int row, int column);
};

class pawn : IPiece {
	bool moveTo (int row, int column) {}
};

class rook : IPiece {
	bool moveTo (int row, int column) {}
};

class king : IPiece {
	bool moveTo (int row, int column) {}
};

class queen : IPiece {
	bool moveTo (int row, int column) {}
};

class knight : IPiece {
	bool moveTo (int row, int column) {}
};

class bishop : IPiece {
	bool moveTo (int row, int column) {}
};

class positionsStore {
	Dictionary<string, IPiece> positionToPiecesMap;
	void updatePosition (int row, int column, IPiece p) { }
	IPiece getPiece(int row, int column) {}
}

class chessPieces {
	ArrayList<IPiece> pieces;
	positionsStore positionMap;

	chessPieces (playerType type, positionsStore map) {}
	bool hasCollision (int oldR, int oldC, int newR, int newC) {}
};

interface IPlayer {
	chessPieces pieces;
	bool takeTurn() {}
};

class computerPlayer : IPlayer {
	bool takeTurn() {
		// select start position to move a piece
		IPiece p = pieces.positionMap.getPiece(row, column);
		// select target cell to place this piece
		if (pieces.positionMap.hasCollision(oldR, oldC, newR, newC)) {
			p.moveTo(row, column, newRow, newColumn);
			pieces.positionMap.updatePosition(newRow, newColumn, p);
		}
	}
};

class humanPlayer : IPlayer {
	bool takeTurn() {}
};

class gameManager {
	Dictionary<playerType, IPlayer> playerMap;
	playerType currentTurn;
	void init() {
		positionsStore map = new positionMap();
		IPlayer player1 = new humanPlayer	(new chessPieces (playerType.black, map));
		IPlayer player2 = new computerPlayer(new chessPieces (playerType.white, map));
		
		playerMap = new Dictionary<playerType, IPlayer> ();
		playerMap[playerType.black] = player1;
		playerMap[playerType.white] = player2;
	}
	
	void play() {
		while (!gameOver) {
			giveTurn();
		}
	}

	void giveTurn (playerType turn) {
		IPlayer player = playerMap[turn];
		if (player.takeTurn()) {
			updateTurn();
		}
	}

	void updateTurn () {
		//
	}
};