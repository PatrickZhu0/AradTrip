using System;

namespace behaviac
{
	// Token: 0x020030BD RID: 12477
	public static class bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event
	{
		// Token: 0x06014A38 RID: 84536 RVA: 0x00636FEC File Offset: 0x006353EC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/BOSS_EVENT/BOSS_EVENT_buwanjia_kuangbao_event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node1 condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node = new Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node1();
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node.HasEvents());
			Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node2 action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node = new Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node2();
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node.SetClassNameString("Action");
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
