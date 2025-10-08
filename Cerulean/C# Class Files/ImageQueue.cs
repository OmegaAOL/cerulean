using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OmegaAOL.SkyBridge;
using System.Drawing.Imaging;

namespace Cerulean
{
    public static class ImageFetcher
    {
        private struct ImageJob
        {
            public string Url;
            public PictureBox Target;
            public bool BackgroundImg;
            public ImageJob(string url, PictureBox target, bool backgroundImg)
            {
                Url = url;
                Target = target;
                BackgroundImg = backgroundImg;
            }
        }

        private static Queue<ImageJob> _queue = new Queue<ImageJob>();
        private static bool _isRunning = false;

        public static void QueueImage(string url, PictureBox pb, bool backgroundImg = false)
        {
            _queue.Enqueue(new ImageJob(url, pb, backgroundImg));

            // Start processing if idle
            if (!_isRunning)
            {
                _isRunning = true;
                ProcessNextImage();
            }
        }

        private static void ProcessNextImage()
        {
            var job = _queue.Dequeue();

            Async.SkyWorker(
                // DoWork
                (s, evt) =>
                {
                    evt.Result = Media.Image.Load(job.Url);
                },
                // Completed
                (s, evt) =>
                {
                    if (evt.Result is Image)
                    {
                        Image img = (Image)evt.Result;
                        if (job.BackgroundImg)
                        {
                            job.Target.BackgroundImage = img;

                        }
                        else
                        {
                            job.Target.Image = img;
                        }
                        
                    }
                    else
                    {
                        CeruleanBox.Display("Error. URL: " + job.Url + "\n\n");
                        Clipboard.SetText(job.Url);
                        try
                        {
                            CeruleanBox.Display(evt.Result.GetType().ToString());
                        }
                        catch (Exception ex) { CeruleanBox.Display(ex.Message); }
                    }

                    // Move to next image in queue
                    ProcessNextImage();
                }
            );
        }
    }
}