using System;

namespace behaviac
{
	// Token: 0x02002F33 RID: 12083
	public static class bt_Monster_AI_Birth_Zhizhu_birth_Event
	{
		// Token: 0x06014738 RID: 83768 RVA: 0x006272C8 File Offset: 0x006256C8
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Birth/Zhizhu_birth_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node1 action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node = new Action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node1();
			action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node.HasEvents());
			Condition_bt_Monster_AI_Birth_Zhizhu_birth_Event_node2 condition_bt_Monster_AI_Birth_Zhizhu_birth_Event_node = new Condition_bt_Monster_AI_Birth_Zhizhu_birth_Event_node2();
			condition_bt_Monster_AI_Birth_Zhizhu_birth_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Birth_Zhizhu_birth_Event_node.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_Birth_Zhizhu_birth_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Birth_Zhizhu_birth_Event_node.HasEvents());
			Action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node3 action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node2 = new Action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node3();
			action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
