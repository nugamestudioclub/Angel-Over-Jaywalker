using System.Collections.Generic;
using UnityEngine;

public class SwitchRenderer : BatchRenderer {
	[SerializeField]
	private bool isOn;
	public bool IsOn => IsOn;

	public bool IsOff => !isOn;

	[SerializeField]
	private ParentRenderer onRenderer;

	[SerializeField]
	private ParentRenderer offRenderer;

	public void Switch() {
		if( isOn )
			SwitchOff();
		else
			SwitchOn();
	}

	public void SwitchOn() {
		onRenderer.Visible = true;
		offRenderer.Visible = false;
	}

	public void SwitchOff() {
		onRenderer.Visible = false;
		offRenderer.Visible = true;
	}

	public override IEnumerable<Renderer> GetAllRenderers() {
		foreach( var renderer in onRenderer.GetAllRenderers() )
			yield return renderer;
		foreach( var renderer in offRenderer.GetAllRenderers() )
			yield return renderer;
	}
}