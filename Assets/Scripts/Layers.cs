using System;
using UnityEngine;
public static class Layers {
	private const int USER_MIN = 6;

	public enum LayerType {
		Default,
		Universal,
		Background,
		Midground,
		Foreground,
	}

	public enum EntityType {
		Scenery,
		Prop,
		NPC,
		Player,
	}

	public static LayerType FromId(int id) {
		return id < USER_MIN
			? LayerType.Default
			: (LayerType)(id - USER_MIN + 1);
	}

	public static int ToId(LayerType layer) {
		return layer == LayerType.Default
			? 0
			: USER_MIN + (int)layer - 1;
	}

	public static string NameOf(LayerType layer) {
		return Enum.GetName(typeof(LayerType), layer);
	}

	public static string NameOf(EntityType entity) {
		return Enum.GetName(typeof(EntityType), entity);
	}

	public static int LayerId(LayerType layer) {
		return LayerMask.NameToLayer(NameOf(layer));
	}

	public static int SortingLayerId(LayerType layer) {
		return SortingLayer.NameToID(NameOf(layer));
	}

	public static int SortingLayerOrder(EntityType entity) {
		return (int)entity;
	}

	public static LayerType UpFrom(LayerType layer) {
		return layer switch {
			LayerType.Universal => LayerType.Universal,
			LayerType.Background => LayerType.Midground,
			LayerType.Midground => LayerType.Foreground,
			LayerType.Foreground => LayerType.Foreground,
			_ => LayerType.Default
		};
	}

	public static LayerType DownFrom(LayerType layer) {
		return layer switch {
			LayerType.Universal => LayerType.Universal,
			LayerType.Foreground => LayerType.Midground,
			LayerType.Midground => LayerType.Background,
			LayerType.Background => LayerType.Background,
			_ => LayerType.Default
		};
	}
}