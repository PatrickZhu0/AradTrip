using System;
using System.Collections;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004768 RID: 18280
	public class CInstanceMember<T> : IInstanceMember
	{
		// Token: 0x0601A46D RID: 107629 RVA: 0x006D72A1 File Offset: 0x006D56A1
		public CInstanceMember()
		{
			this._indexMember = null;
		}

		// Token: 0x0601A46E RID: 107630 RVA: 0x006D72BB File Offset: 0x006D56BB
		public CInstanceMember(string instance, IInstanceMember indexMember)
		{
			this._instance = instance;
			this._indexMember = indexMember;
		}

		// Token: 0x0601A46F RID: 107631 RVA: 0x006D72DC File Offset: 0x006D56DC
		public CInstanceMember(CInstanceMember<T> rhs)
		{
			this._instance = rhs._instance;
			this._indexMember = rhs._indexMember;
		}

		// Token: 0x0601A470 RID: 107632 RVA: 0x006D7308 File Offset: 0x006D5708
		public int GetCount(Agent self)
		{
			IList list = (IList)this.GetValueObject(self);
			if (list != null)
			{
				return list.Count;
			}
			return 0;
		}

		// Token: 0x0601A471 RID: 107633 RVA: 0x006D7330 File Offset: 0x006D5730
		public void SetValue(Agent self, IInstanceMember right, int index)
		{
			object valueObject = right.GetValueObject(self);
			IList list = (IList)valueObject;
			List<T> list2 = (List<T>)list;
			T value = list2[index];
			this.SetValue(self, value);
		}

		// Token: 0x0601A472 RID: 107634 RVA: 0x006D7364 File Offset: 0x006D5764
		public virtual T GetValue(Agent self)
		{
			return default(T);
		}

		// Token: 0x0601A473 RID: 107635 RVA: 0x006D737A File Offset: 0x006D577A
		public object GetValueObject(Agent self)
		{
			return this.GetValue(self);
		}

		// Token: 0x0601A474 RID: 107636 RVA: 0x006D7388 File Offset: 0x006D5788
		public virtual void SetValue(Agent self, T value)
		{
		}

		// Token: 0x0601A475 RID: 107637 RVA: 0x006D738A File Offset: 0x006D578A
		public void SetValue(Agent self, object value)
		{
			this.SetValue(self, (T)((object)value));
		}

		// Token: 0x0601A476 RID: 107638 RVA: 0x006D739C File Offset: 0x006D579C
		public void SetValueAs(Agent self, IInstanceMember right)
		{
			if (typeof(T).IsValueType)
			{
				object valueObject = right.GetValueObject(self);
				object obj = Convert.ChangeType(valueObject, typeof(T));
				T value = (T)((object)obj);
				this.SetValue(self, value);
			}
			else
			{
				object valueObject2 = right.GetValueObject(self);
				this.SetValue(self, valueObject2);
			}
		}

		// Token: 0x0601A477 RID: 107639 RVA: 0x006D73FA File Offset: 0x006D57FA
		public void SetValue(Agent self, IInstanceMember right)
		{
			this.SetValue(self, (CInstanceMember<T>)right);
		}

		// Token: 0x0601A478 RID: 107640 RVA: 0x006D7409 File Offset: 0x006D5809
		public void SetValue(Agent self, CInstanceMember<T> right)
		{
			this.SetValue(self, right.GetValue(self));
		}

		// Token: 0x0601A479 RID: 107641 RVA: 0x006D741C File Offset: 0x006D581C
		public bool Compare(Agent self, IInstanceMember right, EOperatorType comparisonType)
		{
			T value = this.GetValue(self);
			T value2 = ((CInstanceMember<T>)right).GetValue(self);
			return OperationUtils.Compare<T>(value, value2, comparisonType);
		}

		// Token: 0x0601A47A RID: 107642 RVA: 0x006D7448 File Offset: 0x006D5848
		public void Compute(Agent self, IInstanceMember right1, IInstanceMember right2, EOperatorType computeType)
		{
			T value = ((CInstanceMember<T>)right1).GetValue(self);
			T value2 = ((CInstanceMember<T>)right2).GetValue(self);
			this.SetValue(self, OperationUtils.Compute<T>(value, value2, computeType));
		}

		// Token: 0x0601A47B RID: 107643 RVA: 0x006D747F File Offset: 0x006D587F
		public virtual void Run(Agent self)
		{
		}

		// Token: 0x0401270D RID: 75533
		protected string _instance = "Self";

		// Token: 0x0401270E RID: 75534
		protected IInstanceMember _indexMember;
	}
}
