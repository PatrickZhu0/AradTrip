using System;

namespace behaviac
{
	// Token: 0x020030C9 RID: 12489
	public static class bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event
	{
		// Token: 0x06014A4D RID: 84557 RVA: 0x00637580 File Offset: 0x00635980
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/BOSS_EVENT/BOSS_EVENT_wutouqishi_beiji_event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node1 action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node = new Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node1();
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node.SetClassNameString("Action");
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			sequence.AddChild(sequence2);
			Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node3 condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node = new Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node3();
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node.HasEvents());
			Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node4 condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node2 = new Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node4();
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node2.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node2.HasEvents());
			Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node5 condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node3 = new Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node5();
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node3.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node3.HasEvents());
			Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node6 action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node2 = new Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node6();
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node2.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node2.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
