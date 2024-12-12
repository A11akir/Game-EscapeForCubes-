
using UnityEngine;
using Zenject;

public class CharacterInputController : ITickable, IInitializable
{
     private PlayerMovement playerMovement;
     private GameInput gameInput;

    public CharacterInputController(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }

    void IInitializable.Initialize()
    {
        gameInput = new GameInput();

        gameInput.Enable();
    }

    void ITickable.Tick()
    {
        ReadMovement();
    }

    public void DisableInput()
    {
        gameInput.Disable();
    }

    public void EnableInput()
    {
        gameInput.Enable();
    }

    private void ReadMovement()
    {
        var inputDirection = gameInput.Gameplay.Movement.ReadValue<Vector2>();

        var direction = new Vector3(inputDirection.x * playerMovement.Speed * Time.deltaTime, inputDirection.y * playerMovement.Speed * Time.deltaTime, 0);

        playerMovement.Move(direction);
    }
}
