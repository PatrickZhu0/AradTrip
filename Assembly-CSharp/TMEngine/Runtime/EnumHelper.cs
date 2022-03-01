using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046F5 RID: 18165
	public struct EnumHelper<E>
	{
		// Token: 0x0601A0CF RID: 106703 RVA: 0x0081E087 File Offset: 0x0081C487
		public EnumHelper(E flag)
		{
			this.m_Flags = Convert.ToUInt32(flag);
		}

		// Token: 0x0601A0D0 RID: 106704 RVA: 0x0081E09A File Offset: 0x0081C49A
		public EnumHelper(uint flag)
		{
			this.m_Flags = flag;
		}

		// Token: 0x0601A0D1 RID: 106705 RVA: 0x0081E0A3 File Offset: 0x0081C4A3
		public EnumHelper(EnumHelper<E> flag)
		{
			this.m_Flags = flag.m_Flags;
		}

		// Token: 0x0601A0D2 RID: 106706 RVA: 0x0081E0B2 File Offset: 0x0081C4B2
		public bool HasFlag(E flag)
		{
			return 0U != (Convert.ToUInt32(flag) & this.m_Flags);
		}

		// Token: 0x0601A0D3 RID: 106707 RVA: 0x0081E0CC File Offset: 0x0081C4CC
		public void AddFlag(E flag)
		{
			this.m_Flags |= Convert.ToUInt32(flag);
		}

		// Token: 0x0601A0D4 RID: 106708 RVA: 0x0081E0E6 File Offset: 0x0081C4E6
		public void AddFlag(EnumHelper<E> flag)
		{
			this.m_Flags |= flag.m_Flags;
		}

		// Token: 0x0601A0D5 RID: 106709 RVA: 0x0081E0FC File Offset: 0x0081C4FC
		public void RemoveFlag(E flag)
		{
			this.m_Flags &= ~Convert.ToUInt32(flag);
		}

		// Token: 0x0601A0D6 RID: 106710 RVA: 0x0081E117 File Offset: 0x0081C517
		public void RemoveFlag(EnumHelper<E> flag)
		{
			this.m_Flags &= ~flag.m_Flags;
		}

		// Token: 0x0601A0D7 RID: 106711 RVA: 0x0081E130 File Offset: 0x0081C530
		public static EnumHelper<E>operator +(EnumHelper<E> _left, E _right)
		{
			EnumHelper<E> result = new EnumHelper<E>(_left);
			result.AddFlag(_right);
			return result;
		}

		// Token: 0x0601A0D8 RID: 106712 RVA: 0x0081E150 File Offset: 0x0081C550
		public static EnumHelper<E>operator +(E _left, EnumHelper<E> _right)
		{
			EnumHelper<E> result = new EnumHelper<E>(_left);
			result.AddFlag(_right);
			return result;
		}

		// Token: 0x0601A0D9 RID: 106713 RVA: 0x0081E170 File Offset: 0x0081C570
		public static EnumHelper<E>operator +(EnumHelper<E> _left, EnumHelper<E> _right)
		{
			EnumHelper<E> result = new EnumHelper<E>(_left);
			result.AddFlag(_right);
			return result;
		}

		// Token: 0x0601A0DA RID: 106714 RVA: 0x0081E190 File Offset: 0x0081C590
		public static EnumHelper<E>operator -(EnumHelper<E> _left, E _right)
		{
			EnumHelper<E> result = new EnumHelper<E>(_left);
			result.RemoveFlag(_right);
			return result;
		}

		// Token: 0x0601A0DB RID: 106715 RVA: 0x0081E1B0 File Offset: 0x0081C5B0
		public static EnumHelper<E>operator -(E _left, EnumHelper<E> _right)
		{
			EnumHelper<E> result = new EnumHelper<E>(_left);
			result.RemoveFlag(_right);
			return result;
		}

		// Token: 0x0601A0DC RID: 106716 RVA: 0x0081E1D0 File Offset: 0x0081C5D0
		public static EnumHelper<E>operator -(EnumHelper<E> _left, EnumHelper<E> _right)
		{
			EnumHelper<E> result = new EnumHelper<E>(_left);
			result.RemoveFlag(_right);
			return result;
		}

		// Token: 0x0601A0DD RID: 106717 RVA: 0x0081E1EE File Offset: 0x0081C5EE
		public static implicit operator uint(EnumHelper<E> flags)
		{
			return flags.m_Flags;
		}

		// Token: 0x0601A0DE RID: 106718 RVA: 0x0081E1F7 File Offset: 0x0081C5F7
		public static implicit operator int(EnumHelper<E> flags)
		{
			return (int)flags.m_Flags;
		}

		// Token: 0x0401259C RID: 75164
		private uint m_Flags;
	}
}
