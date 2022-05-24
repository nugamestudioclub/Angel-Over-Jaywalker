using System;
using UnityEngine;
public static class Layers {
	private const string DEFAULT = "Default";

	private const int USER_MIN = 6;

	public enum Type {
		Default,
		Universal,
		Background,
		Midground,
		Foreground,
	}

	public enum Subtype {
		Static,
		Dynamic,
	}

	public static Type FromId(int id) {
		return id < USER_MIN
			? Type.Default
			: (Type)(id - USER_MIN + 1);
	}

	public static int ToId(Type type) {
		return type == Type.Default
			? 0
			: USER_MIN + (int)type - 1;
	}

	public static string NameOf(Type type) {
		return Enum.GetName(typeof(Type), type);
	}

	public static string NameOf(Subtype subtype) {
		return Enum.GetName(typeof(Subtype), subtype);
	}

	public static int LayerId(Type type) {
		return LayerMask.NameToLayer(NameOf(type));
	}

	public static int SortingLayerId(Type type, Subtype subtype = Subtype.Static) {

		Debug.Log($"given {type} ({(int)type})");

		string name = type == Type.Default
			? NameOf(type)
			: NameOf(type) + "_" + NameOf(subtype);

		Debug.Log($"name: {name}");
		return SortingLayer.NameToID(name);
	}

	public static Type UpFrom(Type type) {
		return type switch {
			Type.Universal => Type.Universal,
			Type.Background => Type.Midground,
			Type.Midground => Type.Foreground,
			Type.Foreground => Type.Foreground,
			_ => Type.Default
		};
	}

	public static Type DownFrom(Type type) {
		return type switch {
			Type.Universal => Type.Universal,
			Type.Foreground => Type.Midground,
			Type.Midground => Type.Background,
			Type.Background => Type.Background,
			_ => Type.Default
		};
	}
}