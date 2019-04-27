public class Booster : Engine
{

    public override void Initialize()
    {
        // set the players boosters sprite
        SetSprite("Engine", "art/ship/engine");

        base.Initialize();
    }


    /// <summary>
    /// show booster effect on the ship 
    /// </summary>
    /// <param name="flag">toggle this effect on/off</param>
    public void ActivateBooster(bool flag)
    {
        if (flag)
        {
            // set the engine effects sprite if the flag is set to true
            SetSprite("EngineEffect", "art/ship/engineEffect");

            // toggle the particle system active state
            SetParticleEmitterActive(flag);
        }
        else
        {
            // toggle the effect off if its false, set the sprite to null
            SetSprite("EngineEffect", null);

            // toggle particle system inactive state
            SetParticleEmitterActive(flag);
        }

    }

    public override void Update()
    {
        base.Update();
    }

}
