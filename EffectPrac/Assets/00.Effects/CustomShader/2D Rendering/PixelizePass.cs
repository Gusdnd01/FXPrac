using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[VolumeComponentMenuForRenderPipeline("Custom",
typeof(UniversalRenderPipeline))]
public class PixelizePass : ScriptableRenderPass
{
    private PixelizeFeature.CustonPassSetting setting;

    private RenderTargetIdentifier colorBuffer, pixelBuffer;

    private int pixelBufferID = Shader.PropertyToID("_PointBuffer");


    private Material material;
    private int pixelScreenHeight,pixelScreenWidth;

    public string URL = "Hidden/Pixelize";

    public PixelizePass(PixelizeFeature.CustonPassSetting setting){
        this.setting = setting;
        this.renderPassEvent = setting.renderPassEvent;
        if(material == null) material = CoreUtils.CreateEngineMaterial(URL);
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        CommandBuffer cmd = CommandBufferPool.Get();
        using(new ProfilingScope(cmd,new ProfilingSampler("PixelizePass"))){
            Blit(cmd, colorBuffer, pixelBuffer, material);
            Blit(cmd, pixelBuffer, colorBuffer);
        }
        context.ExecuteCommandBuffer(cmd);
        CommandBufferPool.Release(cmd);
    }

    public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
    {
        colorBuffer = renderingData.cameraData.renderer.cameraColorTarget;
        RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;

        pixelScreenHeight = setting.screenHeight;
        pixelScreenWidth = (int)(pixelScreenHeight * renderingData.cameraData.camera.aspect + 0.5f);

        material.SetVector("_BlockCount", new Vector2(pixelScreenWidth, pixelScreenHeight));
        material.SetVector("_BlockSize", new Vector2(1.0f/pixelScreenWidth, 1.0f/pixelScreenHeight));
        material.SetVector("_HalfBlockSize", new Vector2(.5f/pixelScreenWidth,.5f/pixelScreenHeight));

        descriptor.height = pixelScreenHeight;
        descriptor.width = pixelScreenWidth;

        cmd.GetTemporaryRT(pixelBufferID,descriptor,FilterMode.Point);
        pixelBuffer = new RenderTargetIdentifier(pixelBufferID);
    }

    public override void OnCameraCleanup(CommandBuffer cmd)
    {
        if(cmd == null) throw new System.ArgumentNullException("cmd");
        cmd.ReleaseTemporaryRT(pixelBufferID);
    }
}
