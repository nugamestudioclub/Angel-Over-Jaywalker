public class Exit : Threshold {
	protected override void HandleExit(PhysicsEntity entity) {
		if( entity.Layer <= Layer && HeightOf(entity.Collision) <= HeightOf(Collision) )
			entity.MoveLayer(Layers.UpFrom(Layer));
	}
}