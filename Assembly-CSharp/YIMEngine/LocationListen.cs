using System;
using System.Collections.Generic;

namespace YIMEngine
{
	// Token: 0x02004A92 RID: 19090
	public interface LocationListen
	{
		// Token: 0x0601BB26 RID: 113446
		void OnUpdateLocation(ErrorCode errorcode, GeographyLocation location);

		// Token: 0x0601BB27 RID: 113447
		void OnGetNearbyObjects(ErrorCode errorcode, List<RelativeLocation> neighbourList, uint startDistance, uint endDistance);

		// Token: 0x0601BB28 RID: 113448
		void OnGetDistance(ErrorCode errorcode, string userID, uint distance);
	}
}
