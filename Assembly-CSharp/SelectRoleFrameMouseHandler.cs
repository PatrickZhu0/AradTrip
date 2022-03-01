using System;
using GameClient;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000D0B RID: 3339
public class SelectRoleFrameMouseHandler : MonoBehaviour, IDragHandler, IEventSystemHandler
{
	// Token: 0x06008839 RID: 34873 RVA: 0x00184355 File Offset: 0x00182755
	public void Bind(SelectRoleFrame selectRoleFrame, CreateActorFrame createActorFrame)
	{
		this.m_SelectRoleFrame = selectRoleFrame;
		this.m_CreateRoleFrame = createActorFrame;
	}

	// Token: 0x0600883A RID: 34874 RVA: 0x00184368 File Offset: 0x00182768
	public void OnDrag(PointerEventData eventData)
	{
		if (this.m_SelectRoleFrame != null && eventData.dragging)
		{
			this.m_SelectRoleFrame.OnDragSelectRole(eventData.delta.x * 0.6f, true);
		}
		if (this.m_CreateRoleFrame != null && eventData.dragging)
		{
			this.m_CreateRoleFrame.OnDragDemoRole(eventData.delta.x * 0.6f);
		}
	}

	// Token: 0x0400420F RID: 16911
	protected float m_Rotate;

	// Token: 0x04004210 RID: 16912
	protected SelectRoleFrame m_SelectRoleFrame;

	// Token: 0x04004211 RID: 16913
	protected CreateActorFrame m_CreateRoleFrame;
}
