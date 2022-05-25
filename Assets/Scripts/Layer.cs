using UnityEngine;

public enum LayerType {
	Default,
	Universal,
	GroundFloor,
	FirstFloor,
}

public enum LayerSubtype {
	None,
	Interior,
}

public enum SortingOrder {
	Background,
	Foreground,
	NPC,
	Player,
	Floor,
	Collision,
}

public struct Layer {
	private const int USER_MIN = 6;

	public LayerType type;
	public LayerSubtype subtype;

	public Layer(LayerType type, LayerSubtype subtype = LayerSubtype.None) {
		this.type = type;
		this.subtype = subtype;
	}

	public static Layer FromId(int id) {
		return new Layer(TypeFromId(id), SubtypeFromId(id));
	}

	private static LayerType TypeFromId(int id) {
		if( id == 0 )
			return LayerType.Default;
		else if( id == USER_MIN )
			return LayerType.Universal;
		else
			return (LayerType)(2 + (id - USER_MIN - 1) / 2);
	}

	private static LayerSubtype SubtypeFromId(int id) {
		return id <= USER_MIN ? LayerSubtype.None : (LayerSubtype)((id - USER_MIN - 1) % 2);
	}

	public static int ToId(Layer layer) {
		if( layer.type == LayerType.Default )
			return 0;
		else if( layer.type == LayerType.Universal )
			return USER_MIN;
		else
			return 2 * ((int)layer.type - 2) + (int)layer.subtype + USER_MIN + 1;
	}

	public static Layer Inside(Layer layer) {
		return layer.type switch {
			LayerType.Default => layer,
			LayerType.Universal => layer,
			_ => new Layer(LayerType.GroundFloor, LayerSubtype.Interior),
		};
	}

	public static Layer Outside(Layer layer) {
		return new Layer(layer.type, LayerSubtype.None);
	}

	public bool IsInsideOf(Layer other) {
		return type < other.type
			|| (type == other.type && subtype == LayerSubtype.Interior && subtype == other.subtype);
	}

	public bool IsOutsideOf(Layer other) {
		return type > other.type
			|| (type == other.type && subtype != LayerSubtype.Interior && subtype == other.subtype);
	}

	public static int SortingLayerId(Layer layer) {
		return SortingLayer.NameToID(NameOf(layer));
	}

	public static int SortingOrderId(SortingOrder sortingOrder) {
		return (int)sortingOrder;
	}

	public static string NameOf(Layer layer) {
		return NameOf(layer.type) + NameOf(layer.subtype);
	}

	public static string NameOf(LayerType type) {
		return type switch {
			LayerType.Universal => "Universal",
			LayerType.GroundFloor => "Ground_Floor",
			LayerType.FirstFloor => "1st_Floor",
			_ => "Default"
		};
	}

	public static string NameOf(LayerSubtype subtype) {
		return subtype == LayerSubtype.Interior ? "_Interior" : "";
	}
}