public class Entrance : Threshold {
	protected override void HandleExit(PhysicsEntity entity) {
		if( entity.Layer.IsOutsideOf(Layer) && HeightOf(entity.Collider) >= HeightOf(Collider) )
			entity.MoveLayer(Layer.Inside(Layer));
	}
}