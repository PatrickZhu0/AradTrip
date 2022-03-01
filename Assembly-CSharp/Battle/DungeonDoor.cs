using System;

namespace Battle
{
	// Token: 0x0200108E RID: 4238
	public class DungeonDoor
	{
		// Token: 0x04005873 RID: 22643
		public bool isconnectwithboss;

		// Token: 0x04005874 RID: 22644
		public bool isvisited;

		// Token: 0x04005875 RID: 22645
		public ISceneTransportDoorData door;

		// Token: 0x04005876 RID: 22646
		public TransportDoorType doorType = TransportDoorType.None;

		// Token: 0x04005877 RID: 22647
		public bool isEggDoor;
	}
}
