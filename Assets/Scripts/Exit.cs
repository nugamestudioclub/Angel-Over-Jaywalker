public class Exit : Threshold {
	protected override void HandleExit(PhysicsEntity entity) {
		if( entity.Layer.IsInsideOf(Layer) && HeightOf(entity.Collider) <= HeightOf(Collider) )
			entity.MoveLayer(Layer.Outside(Layer));
	}
}