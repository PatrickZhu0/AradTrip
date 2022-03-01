using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E78 RID: 3704
	public class ComButtonEx : Button
	{
		// Token: 0x060092E5 RID: 37605 RVA: 0x001B49E7 File Offset: 0x001B2DE7
		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			this.onMouseDown.Invoke(eventData);
		}

		// Token: 0x060092E6 RID: 37606 RVA: 0x001B49FC File Offset: 0x001B2DFC
		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			this.onMouseUp.Invoke(eventData);
		}

		// Token: 0x060092E7 RID: 37607 RVA: 0x001B4A14 File Offset: 0x001B2E14
		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
			this.onMouseClick.Invoke(eventData);
			if (this.penetrable)
			{
				List<IPointerClickHandler> list = ListPool<IPointerClickHandler>.Get();
				List<RaycastResult> list2 = ListPool<RaycastResult>.Get();
				EventSystem.current.RaycastAll(eventData, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					RaycastResult raycastResult = list2[i];
					if (raycastResult.isValid && raycastResult.gameObject == base.gameObject)
					{
						for (int j = i + 1; j < list2.Count; j++)
						{
							if (list2[j].isValid)
							{
								Graphic component = list2[j].gameObject.GetComponent<Graphic>();
								if (component != null && component.raycastTarget)
								{
									GameObject gameObject = list2[j].gameObject;
									do
									{
										gameObject.GetComponents<IPointerClickHandler>(list);
										if (gameObject.transform.parent != null)
										{
											gameObject = gameObject.transform.parent.gameObject;
										}
										else
										{
											gameObject = null;
										}
									}
									while (list.Count <= 0 && gameObject != null);
									break;
								}
							}
						}
						break;
					}
				}
				ListPool<RaycastResult>.Release(list2);
				for (int k = 0; k < list.Count; k++)
				{
					list[k].OnPointerClick(eventData);
				}
				ListPool<IPointerClickHandler>.Release(list);
			}
		}

		// Token: 0x040049EC RID: 18924
		public bool penetrable = true;

		// Token: 0x040049ED RID: 18925
		public ComButtonEx.MouseEvent onMouseDown = new ComButtonEx.MouseEvent();

		// Token: 0x040049EE RID: 18926
		public ComButtonEx.MouseEvent onMouseUp = new ComButtonEx.MouseEvent();

		// Token: 0x040049EF RID: 18927
		public ComButtonEx.MouseEvent onMouseClick = new ComButtonEx.MouseEvent();

		// Token: 0x02000E79 RID: 3705
		public class MouseEvent : UnityEvent<PointerEventData>
		{
		}
	}
}
