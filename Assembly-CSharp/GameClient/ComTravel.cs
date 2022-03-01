using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000058 RID: 88
	public class ComTravel : MonoBehaviour
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060001FB RID: 507 RVA: 0x000109F8 File Offset: 0x0000EDF8
		public bool Initialized
		{
			get
			{
				return this.bInitialize;
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00010A00 File Offset: 0x0000EE00
		private void Start()
		{
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00010A04 File Offset: 0x0000EE04
		public void Initialize(List<object> datas, ComTravel.OnItemCreate onItemCreate, ComTravel.OnItemVisisble onItemVisible, ComTravel.OnItemDestroy onItemDestroy, ComTravel.OnHitTest onHitTest, ComTravel.OnEnterHitFrame onEnterHitFrame)
		{
			if (datas == null)
			{
				Logger.LogErrorFormat("Initialize datas is null !", new object[0]);
				return;
			}
			if (this.bInitialize)
			{
				return;
			}
			this.bInitialize = true;
			if (null != this.goPrefab)
			{
				this.rectRoot = this.getRect(base.gameObject);
				this.rectPrefab = this.getRect(this.goPrefab);
			}
			if (this.templates == null)
			{
				this.templates = ListPool<ComTravel.Block>.Get();
			}
			this.datas = datas;
			this.onItemCreate = onItemCreate;
			this.onItemVisible = onItemVisible;
			this.onItemDestroy = onItemDestroy;
			this.iHeadPos = 0;
			this.nextPos = (float)this.padLeft;
			this.onHitTest = onHitTest;
			this.onEnterHitFrame = onEnterHitFrame;
			this.createTemplates();
			this.setPos(this.nextPos);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00010ADC File Offset: 0x0000EEDC
		public void SetTravelDatas(List<object> datas)
		{
			this.datas = datas;
			this.hit = null;
			for (int i = 0; i < this.templates.Count; i++)
			{
				int num = -1;
				if (this.datas != null && datas.Count > 0)
				{
					num = (this.iHeadPos + i) % datas.Count;
				}
				if (num != -1 && this.templates[i] != null && this.onItemVisible != null)
				{
					this.onItemVisible(this.templates[i].bindScript, datas[num]);
				}
			}
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00010B84 File Offset: 0x0000EF84
		private Rect getRect(GameObject go)
		{
			Rect rect = default(Rect);
			rect.x = 0f;
			rect.y = 0f;
			rect.width = 0f;
			rect.height = 0f;
			Rect result = rect;
			if (null != go)
			{
				Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(go.transform);
				rect = default(Rect);
				rect.x = bounds.min.x;
				rect.y = bounds.min.y;
				rect.width = bounds.size.x;
				rect.height = bounds.size.y;
				return rect;
			}
			return result;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00010C4C File Offset: 0x0000F04C
		private void createTemplates()
		{
			this.templates.Clear();
			if (null != this.goPrefab)
			{
				int num = Mathf.FloorToInt(this.rectRoot.width / this.rectPrefab.width + 2f);
				for (int i = 0; i < num; i++)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.goPrefab);
					if (null == gameObject)
					{
						Logger.LogErrorFormat("create Template failed !", new object[0]);
					}
					else
					{
						gameObject.CustomActive(true);
						Utility.AttachTo(gameObject, this.goPrefab.transform.parent.gameObject, false);
						CanvasGroup canvasGroup = gameObject.AddComponent<CanvasGroup>();
						canvasGroup.alpha = 0f;
						object obj = null;
						if (this.onItemCreate != null)
						{
							obj = this.onItemCreate(gameObject);
						}
						if (this.onItemVisible != null)
						{
							int num2 = -1;
							if (this.datas != null && this.datas.Count > 0)
							{
								num2 = (this.iHeadPos + i) % this.datas.Count;
							}
							if (num2 != -1)
							{
								this.onItemVisible(obj, this.datas[num2]);
							}
						}
						ComTravel.Block block = new ComTravel.Block
						{
							goTarget = gameObject,
							canvasGroup = canvasGroup,
							bindScript = obj
						};
						block.isVisible = true;
						this.templates.Add(block);
					}
				}
				this.goPrefab.CustomActive(false);
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00010DD0 File Offset: 0x0000F1D0
		private void setPos(float start)
		{
			if (this.templates == null)
			{
				Logger.LogErrorFormat("templates is null!", new object[0]);
				return;
			}
			this.nextPos = start;
			float num = start;
			for (int i = 0; i < this.templates.Count; i++)
			{
				Vector3 localPosition = this.templates[i].goTarget.transform.localPosition;
				this.templates[i].goTarget.transform.localPosition = new Vector3(num, this.templates[i].goTarget.transform.localPosition.y, this.templates[i].goTarget.transform.localPosition.z);
				num += this.rectPrefab.width;
				num += (float)this.padX;
				ComTravel.Block block = this.templates[i];
				block.prevPos = localPosition.x;
				block.curPos = num;
				block.bDirty = false;
			}
			bool flag;
			do
			{
				flag = false;
				if (this.templates.Count > 0)
				{
					ComTravel.Block block2 = this.templates[0];
					if (block2.isVisible && !block2.bDirty && block2.goTarget.transform.localPosition.x < -this.rectPrefab.width)
					{
						block2.isVisible = false;
						this.templates.RemoveAt(0);
						this.templates.Add(block2);
						block2.bDirty = true;
						flag = true;
						this.iHeadPos = (this.iHeadPos + 1) % this.datas.Count;
						this.nextPos = block2.goTarget.transform.localPosition.x + this.rectPrefab.width + (float)this.padX;
					}
				}
			}
			while (flag);
			for (int j = 0; j < this.templates.Count; j++)
			{
				ComTravel.Block block3 = this.templates[j];
				if (!block3.isVisible && block3.curPos <= this.rectRoot.width && block3.curPos >= -this.rectPrefab.width)
				{
					if (this.onItemVisible != null)
					{
						int num2 = -1;
						if (this.datas.Count > 0)
						{
							num2 = (this.iHeadPos + j) % this.datas.Count;
						}
						if (num2 != -1)
						{
							this.onItemVisible(this.templates[j].bindScript, this.datas[num2]);
						}
					}
					block3.isVisible = true;
				}
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x000110B0 File Offset: 0x0000F4B0
		private void Update()
		{
			if (this.bInitialize)
			{
				for (int i = 0; i < this.templates.Count; i++)
				{
					int index = (this.iHeadPos + i) % this.datas.Count;
					if (this.templates[i].isVisible && this.templates[i].goTarget.transform.localPosition.x <= (float)this.iHitX && (float)this.iHitX <= this.templates[i].goTarget.transform.localPosition.x + this.rectPrefab.width && this.onEnterHitFrame != null)
					{
						this.onEnterHitFrame(this.datas[index]);
					}
				}
				if (this.eTravelMode == ComTravel.TravelMode.TMD_HIT)
				{
					int index2 = -1;
					this.iHitIndex = -1;
					int num = 0;
					while (num < this.templates.Count && num < this.iHitMax)
					{
						index2 = (this.iHeadPos + num) % this.datas.Count;
						if (this.onHitTest(this.hit, this.datas[index2]) && this.templates[num].goTarget.transform.localPosition.x > (float)this.iHitX)
						{
							this.iHitIndex = index2;
							index2 = num;
							break;
						}
						num++;
					}
					if (this.iHitIndex == -1)
					{
						this.setPos(this.nextPos - this.curve.Evaluate(1f) * this.speedHigh * Time.deltaTime);
					}
					else
					{
						this.v1 = this.curve.Evaluate(1f) * this.speedHigh;
						this.s1 = this.templates[index2].goTarget.transform.localPosition.x - (float)this.iHitX;
						this.t1 = 2f * this.s1 / this.v1;
						this.a1 = this.v1 / this.t1;
						if (this.t1 <= Time.deltaTime)
						{
							this.setPos(this.nextPos - this.s1);
							this.eTravelMode = ComTravel.TravelMode.TMD_READY_HIT_ADJUST;
							return;
						}
						float num2 = (this.v1 + (this.v1 - Time.deltaTime * this.a1)) * Time.deltaTime * 0.5f;
						this.setPos(this.nextPos - num2);
						this.v1 -= Time.deltaTime * this.a1;
						this.eTravelMode = ComTravel.TravelMode.TMD_HITTING_CACHED;
					}
				}
				else if (this.eTravelMode == ComTravel.TravelMode.TMD_READY_HIT_OVER)
				{
					if (this.onResult != null)
					{
						this.onResult();
					}
					this.eTravelMode = ComTravel.TravelMode.TMD_OVER;
					this.s1 = 0f;
					this.t1 = 0f;
					this.a1 = 0f;
					this.v1 = 0f;
				}
				else if (this.eTravelMode == ComTravel.TravelMode.TMD_READY_HIT_ADJUST)
				{
					ComTravel.Block block = null;
					for (int j = 0; j < this.templates.Count; j++)
					{
						if ((this.iHeadPos + j) % this.datas.Count == this.iHitIndex)
						{
							block = this.templates[j];
							break;
						}
					}
					if (block == null)
					{
						this.eTravelMode = ComTravel.TravelMode.TMD_READY_HIT_OVER;
						return;
					}
					this.s1 = block.goTarget.transform.localPosition.x - (float)this.iHitX;
					if (this.s1 != 0f)
					{
						this.setPos(this.nextPos - this.s1);
					}
					else
					{
						this.eTravelMode = ComTravel.TravelMode.TMD_READY_HIT_OVER;
					}
				}
				else if (this.eTravelMode == ComTravel.TravelMode.TMD_HITTING_CACHED)
				{
					ComTravel.Block block2 = null;
					for (int k = 0; k < this.templates.Count; k++)
					{
						if ((this.iHeadPos + k) % this.datas.Count == this.iHitIndex)
						{
							block2 = this.templates[k];
							break;
						}
					}
					if (block2 == null)
					{
						this.eTravelMode = ComTravel.TravelMode.TMD_READY_HIT_OVER;
						return;
					}
					this.s1 = block2.goTarget.transform.localPosition.x - (float)this.iHitX;
					this.t1 = 2f * this.s1 / this.v1;
					this.a1 = this.v1 / this.t1;
					if (this.t1 <= Time.deltaTime)
					{
						this.setPos(this.nextPos - this.s1);
						this.eTravelMode = ComTravel.TravelMode.TMD_READY_HIT_ADJUST;
						return;
					}
					float num3 = (this.v1 + (this.v1 - Time.deltaTime * this.a1)) * Time.deltaTime * 0.5f;
					this.setPos(this.nextPos - num3);
					this.v1 -= Time.deltaTime * this.a1;
				}
				else if (this.eTravelMode != ComTravel.TravelMode.TMD_HIT && this.eTravelMode != ComTravel.TravelMode.TMD_HITTING)
				{
					this.setPos(this.nextPos - this.getSpeed() * Time.deltaTime);
				}
			}
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00011638 File Offset: 0x0000FA38
		private float getSpeed()
		{
			if (this.eTravelMode == ComTravel.TravelMode.TMD_OVER)
			{
				return 0f;
			}
			if (this.eTravelMode == ComTravel.TravelMode.TMD_NORMAL)
			{
				return this.speedNormal;
			}
			if (this.eTravelMode == ComTravel.TravelMode.TMD_RUNNING)
			{
				return this.speedRunning;
			}
			if (this.eTravelMode == ComTravel.TravelMode.TMD_CURVE)
			{
				float num = Time.time - this.fStartCurveTime;
				num = Mathf.Min(num, this.curveTime);
				float num2 = this.curve.Evaluate(num / this.curveTime);
				float result = num2 * this.speedHigh;
				if (this.onTimeTrigger != null)
				{
					this.onTimeTrigger(num2);
				}
				if (this.fStartCurveTime + this.curveTime <= Time.time)
				{
					result = this.curve.Evaluate(1f) * this.speedHigh;
					this.eTravelMode = ComTravel.TravelMode.TMD_HIT;
				}
				return result;
			}
			Logger.LogErrorFormat("unexpected branch!!", new object[0]);
			return 0f;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00011723 File Offset: 0x0000FB23
		public void StartCurve(ComTravel.OnTimeTrigger onTimeTrigger)
		{
			if (this.eTravelMode != ComTravel.TravelMode.TMD_RUNNING)
			{
				return;
			}
			this.eTravelMode = ComTravel.TravelMode.TMD_CURVE;
			this.onTimeTrigger = onTimeTrigger;
			this.fStartCurveTime = Time.time;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0001174B File Offset: 0x0000FB4B
		public void ChangeToNormal()
		{
			this.eTravelMode = ComTravel.TravelMode.TMD_NORMAL;
			this.fStartCurveTime = 0f;
			this.onTimeTrigger = null;
			this.onResult = null;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0001176D File Offset: 0x0000FB6D
		public void ChangedToRunning()
		{
			this.eTravelMode = ComTravel.TravelMode.TMD_RUNNING;
			this.fStartCurveTime = 0f;
			this.onTimeTrigger = null;
			this.onResult = null;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00011790 File Offset: 0x0000FB90
		private void OnDestroy()
		{
			if (this.templates != null)
			{
				if (this.onItemDestroy != null)
				{
					for (int i = 0; i < this.templates.Count; i++)
					{
						if (this.templates[i] != null)
						{
							this.onItemDestroy(this.templates[i].bindScript);
						}
					}
				}
				ListPool<ComTravel.Block>.Release(this.templates);
				this.templates = null;
			}
			this.onItemCreate = null;
			this.onItemVisible = null;
			this.onItemDestroy = null;
			this.onHitTest = null;
			this.onEnterHitFrame = null;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00011834 File Offset: 0x0000FC34
		public void Hit(object hit, ComTravel.OnResult onResult)
		{
			this.hit = null;
			this.onResult = null;
			if (this.onHitTest != null)
			{
				for (int i = 0; i < this.datas.Count; i++)
				{
					if (this.onHitTest(hit, this.datas[i]))
					{
						this.hit = hit;
						this.onResult = onResult;
						break;
					}
				}
			}
		}

		// Token: 0x040001F6 RID: 502
		public ComTravel.OnItemVisisble onItemVisible;

		// Token: 0x040001F7 RID: 503
		public ComTravel.OnItemCreate onItemCreate;

		// Token: 0x040001F8 RID: 504
		public ComTravel.OnItemDestroy onItemDestroy;

		// Token: 0x040001F9 RID: 505
		public ComTravel.OnTimeTrigger onTimeTrigger;

		// Token: 0x040001FA RID: 506
		public ComTravel.OnHitTest onHitTest;

		// Token: 0x040001FB RID: 507
		public ComTravel.OnResult onResult;

		// Token: 0x040001FC RID: 508
		public ComTravel.OnEnterHitFrame onEnterHitFrame;

		// Token: 0x040001FD RID: 509
		public GameObject goPrefab;

		// Token: 0x040001FE RID: 510
		public int padLeft;

		// Token: 0x040001FF RID: 511
		public int padX;

		// Token: 0x04000200 RID: 512
		public int iHitX;

		// Token: 0x04000201 RID: 513
		public int iHitMax;

		// Token: 0x04000202 RID: 514
		public float speedNormal = 240f;

		// Token: 0x04000203 RID: 515
		public float speedRunning = 1200f;

		// Token: 0x04000204 RID: 516
		public float curveTime = 5f;

		// Token: 0x04000205 RID: 517
		public float speedHigh = 100f;

		// Token: 0x04000206 RID: 518
		public AnimationCurve curve;

		// Token: 0x04000207 RID: 519
		public float hitTime = 4f;

		// Token: 0x04000208 RID: 520
		private Rect rectRoot;

		// Token: 0x04000209 RID: 521
		private Rect rectPrefab;

		// Token: 0x0400020A RID: 522
		private List<ComTravel.Block> templates;

		// Token: 0x0400020B RID: 523
		private List<object> datas;

		// Token: 0x0400020C RID: 524
		private int iHeadPos;

		// Token: 0x0400020D RID: 525
		private float nextPos;

		// Token: 0x0400020E RID: 526
		private ComTravel.TravelMode eTravelMode;

		// Token: 0x0400020F RID: 527
		private float fStartCurveTime;

		// Token: 0x04000210 RID: 528
		private bool bInitialize;

		// Token: 0x04000211 RID: 529
		private float hitCacheSpeed = 120f;

		// Token: 0x04000212 RID: 530
		private int iHitIndex = -1;

		// Token: 0x04000213 RID: 531
		private float v1;

		// Token: 0x04000214 RID: 532
		private float a1;

		// Token: 0x04000215 RID: 533
		private float t1;

		// Token: 0x04000216 RID: 534
		private float s1;

		// Token: 0x04000217 RID: 535
		private object hit;

		// Token: 0x02000059 RID: 89
		// (Invoke) Token: 0x0600020A RID: 522
		public delegate void OnItemVisisble(object script, object data);

		// Token: 0x0200005A RID: 90
		// (Invoke) Token: 0x0600020E RID: 526
		public delegate object OnItemCreate(GameObject go);

		// Token: 0x0200005B RID: 91
		// (Invoke) Token: 0x06000212 RID: 530
		public delegate void OnItemDestroy(object script);

		// Token: 0x0200005C RID: 92
		// (Invoke) Token: 0x06000216 RID: 534
		public delegate void OnTimeTrigger(float fTime);

		// Token: 0x0200005D RID: 93
		// (Invoke) Token: 0x0600021A RID: 538
		public delegate bool OnHitTest(object param, object data);

		// Token: 0x0200005E RID: 94
		// (Invoke) Token: 0x0600021E RID: 542
		public delegate void OnResult();

		// Token: 0x0200005F RID: 95
		// (Invoke) Token: 0x06000222 RID: 546
		public delegate void OnEnterHitFrame(object data);

		// Token: 0x02000060 RID: 96
		public enum TravelMode
		{
			// Token: 0x04000219 RID: 537
			TMD_NORMAL,
			// Token: 0x0400021A RID: 538
			TMD_RUNNING,
			// Token: 0x0400021B RID: 539
			TMD_CURVE,
			// Token: 0x0400021C RID: 540
			TMD_HIT,
			// Token: 0x0400021D RID: 541
			TMD_HITTING,
			// Token: 0x0400021E RID: 542
			TMD_HITTING_CACHED,
			// Token: 0x0400021F RID: 543
			TMD_READY_HIT_ADJUST,
			// Token: 0x04000220 RID: 544
			TMD_READY_HIT_OVER,
			// Token: 0x04000221 RID: 545
			TMD_OVER
		}

		// Token: 0x02000061 RID: 97
		private class Block
		{
			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000226 RID: 550 RVA: 0x000118AE File Offset: 0x0000FCAE
			// (set) Token: 0x06000227 RID: 551 RVA: 0x000118D9 File Offset: 0x0000FCD9
			public bool isVisible
			{
				get
				{
					return null != this.canvasGroup && this.canvasGroup.alpha >= 1f;
				}
				set
				{
					this.canvasGroup.alpha = ((!value) ? 0f : 1f);
				}
			}

			// Token: 0x04000222 RID: 546
			public GameObject goTarget;

			// Token: 0x04000223 RID: 547
			public object bindScript;

			// Token: 0x04000224 RID: 548
			public float prevPos;

			// Token: 0x04000225 RID: 549
			public float curPos;

			// Token: 0x04000226 RID: 550
			public CanvasGroup canvasGroup;

			// Token: 0x04000227 RID: 551
			public bool bDirty;
		}
	}
}
