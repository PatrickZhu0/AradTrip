using System;

namespace behaviac
{
	// Token: 0x020030BA RID: 12474
	public static class bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1
	{
		// Token: 0x06014A33 RID: 84531 RVA: 0x00636E5C File Offset: 0x0063525C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/BOSS_EVENT/BOSS_EVENT_bingxuenvwang_kuangbao_event1");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node1 condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node = new Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node1();
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node.HasEvents());
			Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node2 action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node = new Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node2();
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node.SetClassNameString("Action");
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
