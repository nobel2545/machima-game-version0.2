

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// สร้าง Enum สำหรับระบุ State ของ Battle System
    public enum BattleState
{
    Start,
    Player1SelectSkill,
    Player1SelectBlock,
    Player1Animation,
    Player2SelectSkill,
    Player2SelectBlock,
    Player2Animation,
    Player3SelectSkill,
    Player3SelectBlock,
    Player3Animation,
    EnemyTurn,
    EnemySelectBlock,
    EnemyAnimation,
    Win,
    Lose
}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject unit1;
    public GameObject unit2;
    public GameObject unit3;

    Unit player1Unit;
    Unit player2Unit;
    Unit player3Unit;
	Unit enemyUnit;
    public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

    public GameObject startUI;

    public Animator animator;
    public AnimationClip standbyAnimationClip;
    [SerializeField] public GameObject image;

    public GameObject skillPanel;
    public GameObject blockPanel;

    public float moveSpeed = 5f;
    
    public GameObject eventClick;
    private BattleState currentState; // สถานะปัจจุบันของ Battle System

    public GameObject end1UI;
    public GameObject end2UI;
    

    void Start()
    {
        currentState = BattleState.Start;
        EnterState(currentState);
        
    }
        
    void Update()
    {
        // ตรวจสอบสถานะปัจจุบันและดำเนินการตามเงื่อนไขของแต่ละสถานะ
        switch (currentState)
        {
            case BattleState.Start:
            // กระทำที่ต้องการเมื่อเข้าสู่สถานะ Start
            if (startUI != null)
             {
             startUI.SetActive(true);
             }

             ChangeState(BattleState.Player1SelectSkill);

             break;

            case BattleState.Player1SelectSkill:

            break;

            case BattleState.Player1SelectBlock:
            // เมื่อเข้าสถานะ PlayerSelectBlock

            if (currentState == BattleState.Player1SelectBlock && Input.GetMouseButton(0)) // เพิ่มเงื่อนไข currentState == BattleState.Player1SelectBlock
            {
              // สร้าง Ray จากตำแหน่งของเมาส์
              Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;

              // ตรวจสอบว่า Ray ชนขอบกริดหรือไม่
              if (Physics.Raycast(ray, out hit))
              {
                // ได้ตำแหน่งบนกริดที่ชน
                Vector3 targetPosition = hit.point;

                // ย้ายตำแหน่งของ GameObject unit1 ไปยังตำแหน่งที่ชน
                unit1.transform.position = Vector3.MoveTowards(unit1.transform.position, targetPosition, moveSpeed * Time.deltaTime);
              }
            }

            break;

            case BattleState.Player1Animation:
                // อยู่ในสถานะ PlayerAnimation

            break;

            case BattleState.Player2SelectSkill:

            break;

            case BattleState.Player2SelectBlock:
            // เมื่อเข้าสถานะ PlayerSelectBlock

            if (currentState == BattleState.Player2SelectBlock && Input.GetMouseButton(0)) // เพิ่มเงื่อนไข currentState == BattleState.Player1SelectBlock
            {
              // สร้าง Ray จากตำแหน่งของเมาส์
              Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;

              // ตรวจสอบว่า Ray ชนขอบกริดหรือไม่
              if (Physics.Raycast(ray, out hit))
              {
                // ได้ตำแหน่งบนกริดที่ชน
                Vector3 targetPosition = hit.point;

                // ย้ายตำแหน่งของ GameObject unit1 ไปยังตำแหน่งที่ชน
                unit2.transform.position = Vector3.MoveTowards(unit2.transform.position, targetPosition, moveSpeed * Time.deltaTime);
              }
            }

            break;

            case BattleState.Player2Animation:
                // อยู่ในสถานะ PlayerAnimation
            break;

            case BattleState.Player3SelectSkill:

            break;

            case BattleState.Player3SelectBlock:
            // เมื่อเข้าสถานะ PlayerSelectBlock

            if (currentState == BattleState.Player3SelectBlock && Input.GetMouseButton(0)) // เพิ่มเงื่อนไข currentState == BattleState.Player1SelectBlock
            {
              // สร้าง Ray จากตำแหน่งของเมาส์
              Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;

              // ตรวจสอบว่า Ray ชนขอบกริดหรือไม่
              if (Physics.Raycast(ray, out hit))
              {
                // ได้ตำแหน่งบนกริดที่ชน
                Vector3 targetPosition = hit.point;

                // ย้ายตำแหน่งของ GameObject unit1 ไปยังตำแหน่งที่ชน
                unit3.transform.position = Vector3.MoveTowards(unit3.transform.position, targetPosition, moveSpeed * Time.deltaTime);
              }
            }


            break;

            case BattleState.Player3Animation:
                // อยู่ในสถานะ PlayerAnimation

            break;

            case BattleState.EnemyTurn:
                // อยู่ในสถานะ EnemyTurn
                break;

            case BattleState.EnemySelectBlock:
                // อยู่ในสถานะ EnemySelectBlock
                break;

            case BattleState.EnemyAnimation:
                // อยู่ในสถานะ EnemyAnimation
                break;

            case BattleState.Win:
                // อยู่ในสถานะ Win
                break;

            case BattleState.Lose:
                // อยู่ในสถานะ Lose
                break;
        }
    }

    // เปลี่ยนสถานะปัจจุบันของ Battle System
    private void ChangeState(BattleState newState)
    {
        ExitState(currentState); // ออกจากสถานะปัจจุบัน
        currentState = newState; // เปลี่ยนสถานะ
        EnterState(currentState); // เข้าสู่สถานะใหม่
    }

    // เข้าสู่สถานะ
    private void EnterState(BattleState state)
    {
        switch (state)
        {
            case BattleState.Start:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ Start
                if (standbyAnimationClip != null && standbyAnimationClip != null)
                {
                    animator.Play(standbyAnimationClip.name);
                }
                
                GameObject startUI = GameObject.Find("START");
                if (startUI != null)
                {
                    startUI.SetActive(true);
                }

                break;

            case BattleState.Player1SelectSkill:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ PlayerSelectSkill

                Invoke("DisableImage", 2f); // เรียกใช้ฟังก์ชัน DisableImage หลังจากเวลา 1 วินาที
                
                break;

            case BattleState.Player1SelectBlock:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ PlayerSelectBlock


                break;

            case BattleState.Player1Animation:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ PlayerAnimation
                animator.SetTrigger("TrSkill1");
                OnAttackButton();
                break;

            case BattleState.Player2SelectSkill:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ PlayerSelectSkill
                break;

            case BattleState.Player2SelectBlock:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ PlayerSelectBlock
                break;

            case BattleState.Player2Animation:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ PlayerAnimation
                animator.SetTrigger("TrSkill1");
                OnAttack2Button();
                break;

            case BattleState.Player3SelectSkill:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ PlayerSelectSkill
                break;

            case BattleState.Player3SelectBlock:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ PlayerSelectBlock
                break;

            case BattleState.Player3Animation:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ PlayerAnimation
                animator.SetTrigger("TrSkill1");
                OnAttack3Button();
                break;

            case BattleState.EnemyTurn:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ EnemyTurn
                break;

            case BattleState.EnemySelectBlock:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ EnemySelectBlock
                break;

            case BattleState.EnemyAnimation:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ EnemyAnimation
                break;

            case BattleState.Win:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ Win
                break;

            case BattleState.Lose:
                // กระทำที่ต้องการเมื่อเข้าสู่สถานะ Lose
                break;
        }
    }

    // ออกจากสถานะ
    private void ExitState(BattleState state)
    {
        // ไม่จำเป็นต้องมีการออกจากสถานะ ในที่นี้เราใช้เพียง EnterState เท่านั้น
    }

    private void DisableImage()
    {
    image.SetActive(false);
    }

    public void ChangeToMoveStateCoroutine()
    {
        ChangeState(BattleState.Player1SelectBlock); // เปลี่ยนสถานะเมื่อ Coroutine ทำงานเสร็จสิ้น
    }

    public void ChangeToAnimateStateCoroutine()
    {
        ChangeState(BattleState.Player1Animation); // เปลี่ยนสถานะเมื่อ Coroutine ทำงานเสร็จสิ้น
    }

    public void ChangeToMove2StateCoroutine()
    {
        ChangeState(BattleState.Player2SelectBlock); // เปลี่ยนสถานะเมื่อ Coroutine ทำงานเสร็จสิ้น
    }

    public void ChangeToAnimate2StateCoroutine()
    {
        ChangeState(BattleState.Player2Animation); // เปลี่ยนสถานะเมื่อ Coroutine ทำงานเสร็จสิ้น
    }

    public void ChangeToMove3StateCoroutine()
    {
        ChangeState(BattleState.Player3SelectBlock); // เปลี่ยนสถานะเมื่อ Coroutine ทำงานเสร็จสิ้น
    }

    public void ChangeToAnimate3StateCoroutine()
    {
        ChangeState(BattleState.Player3Animation); // เปลี่ยนสถานะเมื่อ Coroutine ทำงานเสร็จสิ้น
    }

    public void OnAttackButton()
	{
		if (currentState != BattleState.Player1Animation)
			return;

		StartCoroutine(PlayerAttack());
	}

    public void OnAttack2Button()
	{
		if (currentState != BattleState.Player2Animation)
			return;

		StartCoroutine(PlayerAttack2());
	}

    public void OnAttack3Button()
	{
		if (currentState != BattleState.Player3Animation)
			return;

		StartCoroutine(PlayerAttack3());
	}


    IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(player1Unit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			currentState = BattleState.Win;
			EndBattle();
		} else
		{
			currentState = BattleState.EnemyTurn;
			ChangeState(BattleState.Player2SelectSkill);
		}
	}

    IEnumerator PlayerAttack2()
	{
		bool isDead = enemyUnit.TakeDamage(player2Unit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			currentState = BattleState.Win;
			EndBattle();
		} else
		{
			currentState = BattleState.EnemyTurn;
			ChangeState(BattleState.Player3SelectSkill);
		}
	}

    IEnumerator PlayerAttack3()
	{
		bool isDead = enemyUnit.TakeDamage(player3Unit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			currentState = BattleState.Win;
			EndBattle();
		} else
		{
			currentState = BattleState.EnemyTurn;
			ChangeState(BattleState.EnemyTurn);
		}
	}

    IEnumerator EnemyTurn()
	{

		bool isDead = player1Unit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(player1Unit.currentHP);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			currentState = BattleState.Lose;
			EndBattle();
		} else
		{
			currentState = BattleState.Player1SelectSkill;
			PlayerTurn();
		}

	}

    void EndBattle()
	{
		if(currentState == BattleState.Win)
		{
			end1UI.SetActive(true);
		} else if (currentState == BattleState.Lose) 
        {
            end2UI.SetActive(true);
        }
	}

    void PlayerTurn()
	{
		
	}

}


